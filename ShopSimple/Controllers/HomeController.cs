using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSimple.Models;

namespace ShopSimple.Controllers;

public class HomeController(ShopSimpleDbContext context, ILogger<HomeController> logger) : Controller
{
    public IActionResult Index()
    {
        var orderItemsWithImages = context.OrderItems
            .Where(oi => oi.ImageData != null)
            .ToList();

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
