using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] prod = new Product[]
        {
            new Product() { Id = 1, Cena = 123, Ime = "Paradižnikova Juha", Kategorija = "Hrana" },
            new Product() { Id = 2, Cena = 0.2m, Ime = "Žoga", Kategorija = "Igraca" },
            new Product() { Id = 3, Cena = 222, Ime = "Kladivo", Kategorija = "Orodje" },
        };

        public IList<Product> GetProducts()
        {
            return prod;
        }

        public Product GetProduct(int id)
        {
            return GetProducts()[id];
        }
    }
}
