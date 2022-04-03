using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var orders = await dbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Book)
                .ToListAsync();

            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Order order)
        {
            if (ModelState.IsValid)
            {
                dbContext.Orders.Add(order);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> AddBook(int id)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return NotFound();

            var model = new CreateOrderDetailViewModel()
            {
                OrderId = id,
                Books = new SelectList(await dbContext.Books.ToListAsync(), "Id", "Title").ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(CreateOrderDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = await dbContext.Books.FirstAsync(b => b.Id == model.BookId);

                var orderDetail = new OrderDetail()
                {
                    OrderId = model.OrderId,
                    BookId = model.BookId,
                    Quantity = model.Quantity,
                    TotalPrice = book.Price * model.Quantity,
                };

                dbContext.OrderDetails.Add(orderDetail);

                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            model.Books = new SelectList(await dbContext.Books.ToListAsync(), "Id", "Title").ToList();
            return View(model);
        }
    }
}
