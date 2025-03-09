using System.ComponentModel.DataAnnotations;

namespace ShopSimple.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public string Address { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }

}
