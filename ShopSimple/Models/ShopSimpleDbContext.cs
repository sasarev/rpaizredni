using Microsoft.EntityFrameworkCore;

namespace ShopSimple.Models
{
    public class ShopSimpleDbContext(DbContextOptions<ShopSimpleDbContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(solutionDirectory,"..", "..", "..", "ShopSimple.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            Console.WriteLine($"Database Path: {dbPath}");
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShopSimple.Models.Order> Orders { get; set; }
    }
}
