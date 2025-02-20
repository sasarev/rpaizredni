using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KlicAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CallAPI().Wait();
        }

        private static async Task CallAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44376");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( 
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // var test = await client.GetStringAsync("/api/Products/1");

                HttpResponseMessage msg = await client.GetAsync("/api/Products/1");
                var prod = await msg.Content.ReadAsAsync<Product>();

                Console.WriteLine(prod.Ime);

                HttpResponseMessage msgList = await client.GetAsync("/api/Products");
                var prodList = await msgList.Content.ReadAsAsync<IList<Product>>();

                foreach(var p in prodList)
                {
                    Console.WriteLine(p.Ime);
                }               
            }
        }
    }
}
