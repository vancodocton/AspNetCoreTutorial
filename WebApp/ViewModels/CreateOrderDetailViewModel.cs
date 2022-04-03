using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class CreateOrderDetailViewModel
    {
        [ValidateNever]
        public List<SelectListItem> Books { get; set; } = null!;

        public int OrderId { get; set; }

        public int BookId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be positive.")]
        public int Quantity { get; set; }
    }
}
