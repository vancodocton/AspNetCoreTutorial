using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            await SeedCategoryData(serviceProvider.GetRequiredService<ApplicationDbContext>());
        }

        private static async Task SeedCategoryData(ApplicationDbContext dbContext)
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Commic",
                    Description = null,
                },
                new Category()
                {
                    Name = "Novel",
                    Description = null,
                },
            };

            foreach (var category in categories)
            {
                if (!await dbContext.Categories.AnyAsync(c => c.Name == category.Name))
                {
                    dbContext.Categories.Add(category);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
