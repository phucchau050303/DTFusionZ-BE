using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Data;
using Microsoft.EntityFrameworkCore;

namespace DTFusionZ_BE.Utilities.Seeder
{
    public class DataSeeder
    {
        public static void SeedData(DTFusionZDbContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new[]
            {
                new Category { Name = "Rice Bowl", Items = new List<Item>
                {
                    new Item { Name = "Chicken Teriyaki Rice Bowl", Description = "Grilled chicken with teriyaki sauce over steamed rice.", Price = 7.5m, ImageUrl = "https://example.com/images/chicken_teriyaki_rice_bowl.jpg" },
                    new Item { Name = "Chicken Katsucurry", Description = "Breaded chicken thigh with rice and curry.", Price = 11.99m, ImageUrl = "https://example.com/images/chicken_katsucurry.jpg" },
                } },
                new Category { Name = "Bento" , Items = new List<Item>
                {
                    new Item { Name = "Pepper Crust Tuna Bento", Description = "Grilled Tuna with rice, salad, and miso sauce.", Price = 12.99m, ImageUrl = "https://example.com/images/salmon_bento.jpg" },
                    new Item { Name = "Chicken Teriyaki Bento", Description = "Grilled chicken with teriyaki sauce Bento.", Price = 8.99m, ImageUrl = "https://example.com/images/chicken_teriyaki_rice_bowl.jpg" },
                } },
                new Category { Name = "Fish And Chips" , Items = new List<Item>
                {
                    new Item { Name = "Classic Fish and Chips", Description = "Battered fish fillet with fries and tartar sauce.", Price = 10.99m, ImageUrl = "https://example.com/images/classic_fish_and_chips.jpg" },
                } }
            };

            context.Categories.AddRange(categories);
            
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving data: {ex.Message}");
                // Optionally, log the exception details to a file or other logging mechanism
            }
        }
    }
}