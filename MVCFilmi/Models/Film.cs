using System;

namespace MVCFilmi.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime Izdan { get; set; }
        public string Tip { get; set; }
        public decimal Cena { get; set; }
    }
}