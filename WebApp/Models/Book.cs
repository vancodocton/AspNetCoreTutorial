using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }
    }
}
