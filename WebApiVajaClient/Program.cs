using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace WebApiVajaClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CallAPI().Wait();
            // PostAPI(args).Wait();
        }

        private static async Task CallAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msgList = await client.GetAsync("/api/Mentors");
                var mentors = await msgList.Content.ReadAsAsync<IList<Mentor>>();

                foreach (var p in mentors.Where(x=>x.MenIme is not null))
                {
                    Console.WriteLine(p.MenIme);
                }
            }
        }

        private static async Task PostAPI(string[] args)
        {
            Console.WriteLine(args.Count());
            if (args.Count() < 2)
            {
                Console.WriteLine("Too few paramters.");
                return;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

               
                var newMentor = new Mentor
                {
                    MenIme = args[0],
                    MenPriimek = args[1],
                };

                var jsonContent = JsonConvert.SerializeObject(newMentor);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/api/Mentors", content);
            }
        }
    }
}
