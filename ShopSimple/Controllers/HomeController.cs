using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSimple.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ShopSimple.Controllers;

public class HomeController(ShopSimpleDbContext context, ILogger<HomeController> logger) : Controller
{
    private byte[] RemoveWhiteBackground(byte[] imageData)
    {
        using (var image = Image.Load<Rgba32>(imageData))
        {
            image.Mutate(ctx =>
            {
                // Loop through each pixel and make white areas transparent
                image.ProcessPixelRows(accessor =>
                {
                    for (int y = 0; y < accessor.Height; y++)
                    {
                        var row = accessor.GetRowSpan(y);
                        for (int x = 0; x < row.Length; x++)
                        {
                            var pixel = row[x];

                            // Detect white background (adjust tolerance as needed)
                            if (pixel.R > 200 && pixel.G > 200 && pixel.B > 200) // If it's close to white
                            {
                                row[x] = new Rgba32(255, 255, 255, 0); // Make it fully transparent
                            }
                        }
                    }
                });
            });

            using (var ms = new MemoryStream())
            {
                image.SaveAsPng(ms); // Save as PNG to retain transparency
                return ms.ToArray();
            }
        }
    }

    public IActionResult Index()
    {
        var orderItemsWithImages = context.OrderItems
            .Where(oi => oi.ImageData != null)
            .ToList();
        
        // Process each image to remove white background
        foreach (var item in orderItemsWithImages)
        {
            item.ImageData = RemoveWhiteBackground(item.ImageData);
        }

        return View(orderItemsWithImages);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
