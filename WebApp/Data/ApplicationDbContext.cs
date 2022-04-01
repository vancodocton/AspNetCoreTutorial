using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>() 
                .HasKey(c => new { c.OrderId, c.BookId });

            base.OnModelCreating(builder);
        }
    }
}