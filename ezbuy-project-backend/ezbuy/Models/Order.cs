using System.ComponentModel.DataAnnotations;

namespace ezbuy.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
