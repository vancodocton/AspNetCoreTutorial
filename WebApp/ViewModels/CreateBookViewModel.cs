using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class CreateBookViewModel
    {
        public Book Book { get; set; } = null!;

        [ValidateNever]
        public SelectList Categories { get; set; } = null!;

        public string Message { get; set; } = "Ditmemay asp.net core";
    }
}
