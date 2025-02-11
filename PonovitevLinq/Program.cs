using System;
using System.Linq;
using System.Reflection.Emit;

namespace PonovitevLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ExampleA();
            // ExampleC();
            // ExampleD();
            // ExampleE();
            // ExampleH();
            ExampleJ();
        }

        private static void ExampleA()
        {

            Console.WriteLine(Environment.NewLine + "EXAMPLE A " + Environment.NewLine);

            BazaZaVajeEntities bazaZaVajeEntities = new BazaZaVajeEntities();

            var d1 = DateTime.Parse("20.1.2004");
            var result = bazaZaVajeEntities.PRODUKT.Where(x => x.P_DATUM < d1);

            foreach (var entity in result)
            {
                Console.WriteLine(entity.P_OPIS + " " + entity.P_CENA);
            }

        }

        /// <summary>
        /// c. izberi P_OPIS, P_ZALOGA, P_MIN,P_CENA iz tabele PRODUKT, kjer je P_CENA manjša od 50 in je P_DATUM večji kot 15. jan. 2004
        /// </summary>
        private static void ExampleC()
        {
            Console.WriteLine(Environment.NewLine + "EXAMPLE B " + Environment.NewLine);

            BazaZaVajeEntities bazaZaVajeEntities = new BazaZaVajeEntities();

            var minData = DateTime.Parse("15.1.2004");

            var result = bazaZaVajeEntities.PRODUKT.Where(x => x.P_CENA < 50 && x.P_DATUM > minData);


            foreach (var entity in result)
            {
                Console.WriteLine($"{entity.P_OPIS}, {entity.P_ZALOGA}, {entity.P_MIN}, {entity.P_CENA}");
            }
        }

        /// <summary>
        /// izberi vse atribute iz tabele DOBAVITELJ katerih ime se začne s Smith
        /// </summary>
        private static void ExampleD()
        {
            Console.WriteLine(Environment.NewLine + "EXAMPLE D " + Environment.NewLine);

            BazaZaVajeEntities bazaZaVajeEntities = new BazaZaVajeEntities();

            var result = bazaZaVajeEntities.DOBAVITELJ.Where(x => x.D_KONTAKT.StartsWith("Smith"));


            foreach (var entity in result)
            {
                Console.WriteLine($"{entity.D_IME}, {entity.D_KONTAKT}, {entity.D_KODA}");
            }
        }

        /// <summary>
        /// izberi vse dobavitelje, kjer je zaloga v produktu manjša od dvakratnika minimalne zaloge
        /// </summary>
        private static void ExampleE()
        {
            Console.WriteLine(Environment.NewLine + "EXAMPLE E " + Environment.NewLine);

            BazaZaVajeEntities bazaZaVajeEntities = new BazaZaVajeEntities();

            var result = bazaZaVajeEntities.PRODUKT.Where(x => x.P_ZALOGA < (2 * x.P_MIN)).Where(x => x.DOBAVITELJ != null);
                
            foreach (var entity in result)
            {
                Console.WriteLine($"{entity.DOBAVITELJ.D_IME} {entity.P_ZALOGA} {entity.P_MIN}");
            }
        }

        /// <summary>
        /// izpiši vsoto vseh stanj pri kupcih (KUP_STANJE) (2089,28)
        /// </summary>
        private static void ExampleH()
        {
            Console.WriteLine(Environment.NewLine + "EXAMPLE H " + Environment.NewLine);

            BazaZaVajeEntities bazaZaVajeEntities = new BazaZaVajeEntities();

            var result = bazaZaVajeEntities.KUPEC.Sum(x => x.KUP_STANJE);

            Console.WriteLine(result);
        }

        /// <summary>
        /// j. izpiši število različnih produktov posameznega dobavitelja po posameznem dobavitelju iz
        /// tabele produkt(rešitev ima 6 vrstic, če izključimo dobavitelja null)
        /// </summary>
        private static void ExampleJ()
        {
            Console.WriteLine(Environment.NewLine + "EXAMPLE J " + Environment.NewLine);

            BazaZaVajeEntities bazaZaVajeEntities = new BazaZaVajeEntities();

            var result = bazaZaVajeEntities.DOBAVITELJ.Where(x => x.D_KODA != null).GroupBy(c => c.D_KODA)
                .Select(x => new { Dob = x.Key, DistProdCount = x.Count() }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"Dobavitelj: {item.Dob}, Distinct Products: {item.DistProdCount}");
            }
        }

    }
}
