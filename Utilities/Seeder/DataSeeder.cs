using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Data;
using Microsoft.EntityFrameworkCore;

namespace DTFusionZ_BE.Utilities.Seeder
{
    public class DataSeeder
    {
        public static void SeedData(DTFusionZDbContext context)
        {
            if (context.Categories.Any() || context.Items.Any()) return;

            var categories = new[]
            {
                new Category { Name = "Rice Bowl" },
                new Category { Name = "Bento" },
                new Category { Name = "Fish And Chips" }
            };

            var items = new[]
            {
                new Item { Name = "Chicken Teriyaki Bento", Description = "Grilled chicken with teriyaki sauce Bento.", Price = 8.99m, Category = categories[1], ImageUrl = "https://example.com/images/chicken_teriyaki_rice_bowl.jpg" },
                new Item { Name = "Beef Bulgogi Rice Bowl", Description = "Marinated beef with vegetables over steamed rice.", Price = 9.99m, Category = categories[0], ImageUrl = "https://example.com/images/beef_bulgogi_rice_bowl.jpg" },
                new Item { Name = "Salmon Bento", Description = "Grilled salmon with rice, salad, and miso soup.", Price = 12.99m, Category = categories[1], ImageUrl = "https://example.com/images/salmon_bento.jpg" },
                new Item { Name = "Chicken Katsucurry", Description = "Breaded chicken thigh with rice and curry.", Price = 11.99m, Category = categories[0], ImageUrl = "https://example.com/images/chicken_katsucurry.jpg" },
                new Item { Name = "Classic Fish and Chips", Description = "Battered fish fillet with fries and tartar sauce.", Price = 10.99m, Category = categories[2], ImageUrl = "https://example.com/images/classic_fish_and_chips.jpg" },
            };

            context.Categories.AddRange(categories);
            context.Items.AddRange(items);
            context.SaveChanges();
        }

 // DB has been seeded


    }
}