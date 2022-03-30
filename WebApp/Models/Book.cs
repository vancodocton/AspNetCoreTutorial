using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }
    }
}
