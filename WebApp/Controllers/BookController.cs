using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var books = await dbContext.Books
                .Include(b => b.Category)
                .ToListAsync();

            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateBookViewModel();
            var categories = await dbContext.Categories.ToListAsync();

            model.Categories = new SelectList(categories, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            // check model is valid
            if (ModelState.IsValid)
            {
                // if true then save to database
                Book book = model.Book;

                dbContext.Books.Add(book);

                await dbContext.SaveChangesAsync();
            }
            else
            {
                // load categories again to model and return to view with errors.
                var categories = await dbContext.Categories.ToListAsync();

                model.Categories = new SelectList(categories, "Id", "Name");

                return View(model);
            }

            // Redirect to database
            return RedirectToAction("Index");
        }
    }
}
