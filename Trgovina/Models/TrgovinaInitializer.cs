using System.Collections.Generic;
using System.Data.Entity;
using Trgovina.Data;

namespace Trgovina.Models
{
    public class TrgovinaInitializer : DropCreateDatabaseIfModelChanges<TrgovinaContext>
    {
        protected override void Seed(TrgovinaContext context)
        {
            var products = new List<Product>()
            {
                new Product { Id = 1, Name="Juho", ActualCost = 1.3M, Price = 0.99m },
                new Product { Id = 1, Name="Kladivo", ActualCost = 16.99M, Price = 10m },
                new Product { Id = 1, Name="Test", ActualCost = 1.6M, Price = 2.0m },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            var order = new Order() { Customer = "Bob" };
            var od = new List<OrderDetail>()
            {
                new OrderDetail() { Product = products[0], Quantity = 2, Order = order },
                new OrderDetail() { Product = products[1], Quantity = 4, Order = order },
            };

            context.Orders.Add(order);
            foreach(var ord in od)
            {
                 context.OrderDetails.Add(ord);
            }

            context.SaveChanges();
        }
    }
}
