// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using System.Text.Json;
using ShopSimple.Models;

await GetOrderData();


static async Task GetOrderData()
{
    using var client = new HttpClient();
    client.BaseAddress = new Uri("https://localhost:7002/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

    HttpResponseMessage response = await client.GetAsync("/api/OrdersDetails");
    if (response.IsSuccessStatusCode)
    {
        string jsonResponse = await response.Content.ReadAsStringAsync();

        var orderDetails = JsonSerializer.Deserialize<List<Order>>(jsonResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        // Display the fetched order details
        foreach (var order in orderDetails)
        {
            Console.WriteLine($"ID: {order.OrderId}, Status: {order.Status}, Total Amount: {order.TotalAmount}");
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
    }
}