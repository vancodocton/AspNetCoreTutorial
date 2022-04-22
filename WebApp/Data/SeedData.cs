using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            await SeedCategoryData(serviceProvider.GetRequiredService<ApplicationDbContext>());

            await SeedUserRoles(serviceProvider.GetRequiredService<RoleManager<IdentityRole>>());
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

        private static async Task SeedUserRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = new List<string>()
            {
                "Seller", "Customer" 
            };

            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role) == false)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
