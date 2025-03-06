namespace WebApiVajaClient
{
    public partial class Mentor
    {
        public int MenId { get; set; }
        public string MenIme { get; set; }
        public string MenPriimek { get; set; }
        public string MenVloga { get; set; }
        public string MenNaziv { get; set; }
        public string MenUstanova { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
    }
}
