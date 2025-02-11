using System;
using System.Linq;

namespace Elektrika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElektrikaEntities1 entities = new ElektrikaEntities1();

            var specificDateTime = new DateTime(2013, 8, 18, 0, 0, 0);

            var result = entities.Meritve
                .Where(x => x.ZapisČas.HasValue &&
                            x.ZapisČas.Value.Year == specificDateTime.Year &&
                            x.ZapisČas.Value.Month == specificDateTime.Month && 
                            x.ZapisČas.Value.Hour == specificDateTime.Hour)
                .GroupBy(x => x.ZapisČas.Value.Hour)
                .Select(x => new { Ura = x.Key, Moc = x.Average(b => b.kW1 + b.kW2 + b.kW3) })
                .ToList();
        }
    }
}
