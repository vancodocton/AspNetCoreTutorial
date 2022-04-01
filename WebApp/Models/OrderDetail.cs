using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        [Range(0, 10, ErrorMessage = "Quantity must be positive.")]
        public int Quantity { get; set; }

        public double TotalPrice { get; set; }
    }
}
