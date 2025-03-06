using System.Data.Entity;

namespace Trgovina.Data
{
    public class TrgovinaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TrgovinaContext() : base("name=TrgovinaContext")
        {
        }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderDetail> OrderDetails { get; set; }
    }
}
