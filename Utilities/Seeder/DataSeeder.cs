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

            //Define Options Groups and Values

            var fncSizeOptionGroup = new OptionGroup
            {
                Name = "Size",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Small", PriceModifier = 0m },
                    new OptionValue { Name = "Medium", PriceModifier = 10m },
                    new OptionValue { Name = "Large", PriceModifier = 20m },
                    new OptionValue { Name = "Jumbo", PriceModifier = 30m },
                }
            };

            var alternativeSauceOptionGroup = new OptionGroup
            {
                Name = "Alternative Sauce",
                IsRequired = false,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "No Sauce", PriceModifier = 0m },
                    new OptionValue { Name = "Gochujang Sauce", PriceModifier = 0m },
                    new OptionValue { Name = "Teriyaki Sauce", PriceModifier = 0m },
                    new OptionValue { Name = "Tonkatsu Sauce", PriceModifier = 0m },
                    new OptionValue { Name = "Miso Sauce", PriceModifier = 0m },
                    new OptionValue { Name = "Sesame Sauce", PriceModifier = 0m },
                }
            };

            var extraMisoOptionGroup = new OptionGroup
            {
                Name = "Extra Miso",
                IsRequired = false,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Miso Soup", PriceModifier = 5m },
                }
            };

            var extraCurryOptionGroup = new OptionGroup
            {
                Name = "Extra Curry",
                IsRequired = false,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Extra Curry", PriceModifier = 5m },
                }
            };

            var fishforBentoAndRiceBowlOptionGroup = new OptionGroup
            {
                Name = "Fish Selection",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Snapper", PriceModifier = 0m },
                    new OptionValue { Name = "Barramundi", PriceModifier = 0m },
                    new OptionValue { Name = "Basa", PriceModifier = 0m },
                }
            };

            var sobaNoodleToppingOptionGroup = new OptionGroup
            {
                Name = "Soba Noodle Topping",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Prawn", PriceModifier = 0m },
                    new OptionValue { Name = "Chicken Katsu", PriceModifier = 0m },
                    new OptionValue { Name = "Chicken Teriyaki", PriceModifier = 0m },
                    new OptionValue { Name = "Tonkatsu Pork", PriceModifier = 0m },
                    new OptionValue { Name = "Marinated Beef", PriceModifier = 0m },
                    new OptionValue { Name = "Salmon/Tuna", PriceModifier = 0m },
                }
            };

            var togarashiCalamariSideDishOptionGroup = new OptionGroup 
            { 
                Name = "Calamari Side Dish",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Hot Chips", PriceModifier = 0m },
                    new OptionValue { Name = "Salad", PriceModifier = 0m },
                }
            };

            var vegetarianOrVegan = new OptionGroup
            {
                Name = "Dietary Preference",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Vegetarian", PriceModifier = 0m },
                    new OptionValue { Name = "Vegan", PriceModifier = 0m },
                }
            };

            var vietnameseSaladProteinOptionGroup = new OptionGroup
            {
                Name = "Protein Choice",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Chicken", PriceModifier = 0m },
                    new OptionValue { Name = "Prawn", PriceModifier = 0m },
                    new OptionValue { Name = "Beef", PriceModifier = 0m },
                }
            };

            var chipsSauceOptionGroup = new OptionGroup
            {
                Name = "Sauce Choice",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Ketchup", PriceModifier = 0m },
                    new OptionValue { Name = "Mayonnaise", PriceModifier = 0m },
                    new OptionValue { Name = "Sweet Chili Sauce", PriceModifier = 0m },
                }
            };

            var prawnBentoSauceOptionGroup = new OptionGroup
            {
                Name = "Sauce Choice",
                IsRequired = true,
                MaxSelections = 1,
                OptionValues = new List<OptionValue>
                {
                    new OptionValue { Name = "Chilli Garlic Sauce", PriceModifier = 0m },
                    new OptionValue { Name = "Teriyaki Sauce", PriceModifier = 0m },
                }
            };


            //Define Rice Bowl Items

            var bibimbap = new Item
            {
                Name = "Bibimbap",
                Description = "Bibimbap, translating to \"mixed rice,\" is arguably the most recognizable and beloved dish in Korean" +
                        " cuisine. It's an explosion of color and texture meticulously arranged in a single bowl.\r\n\r\nWe start with a " +
                        "base of fluffy white rice, then artfully arrange at least five vibrant toppings, including crunchy julienned " +
                        "carrots, tender spinach, earthy shiitake mushrooms, and savory marinated beef (bulgogi style). Crowned with a " +
                        "perfectly sunny-side-up egg, the ritual of Bibimbap begins when you stir everything together with a generous " +
                        "dollop of our homemade, subtly sweet and spicy gochujang sauce.",
                ShortDescription = "A beautifully arranged bowl of warm rice topped with seasoned vegetables, marinated meat, a fried egg, and our spicy gochujang sauce. Mix for the perfect, satisfying bite.",
                Price = 25m,
                ImageUrl = "https://dtfusionzstorage.blob.core.windows.net/menu-images/Bibimbap.png",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = alternativeSauceOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup },
                }
            };

            var chickenKatsucurry = new Item
            {
                Name = "Chicken Katsucurry",
                Description = "Experience the ultimate Japanese comfort food. Our Chicken Katsu features a boneless chicken thigh, lightly pounded, seasoned, and coated in authentic, coarse Panko breadcrumbs to achieve an unparalleled crunch. It is expertly fried to a perfect golden hue.\r\n\r\nThe crispy katsu is sliced and placed atop a bed of warm Japanese rice, then generously draped with our homemade curry sauce—a deeply flavored, slightly sweet, and savory sauce simmered with caramelized onions and carrots. A truly satisfying combination of textures and flavors.",
                ShortDescription = "Pank crumbed juicy chicken thigh fillet with creamy curry with carrots",
                Price = 20m,
                ImageUrl = "https://dtfusionzstorage.blob.core.windows.net/menu-images/Curry.png",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = extraCurryOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup },
                }
            };

            var grilledFishRiceBowl = new Item
            {
                Name = "Grilled Fish Rice Bowl",
                Description = "A light and flavorful rice bowl featuring a generous fillet of perfectly grilled white fish (e.g., Barramundi or Cod). It is elegantly finished with a savory reduction of soy sauce, tender Japanese mushrooms, and slivers of bright spring onion. A healthy and delicious choice.",
                ShortDescription = "Grilled fish topped with Japanese mushrooms, fresh spring onions, and a delicate soy glaze. Served over rice.",
                Price = 20m,
                ImageUrl = "",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = fishforBentoAndRiceBowlOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup },
                }
            };

            var veggieBibimbap = new Item
            {
                Name = "Vegetarian/Vegan Bibimbap",
                Description = "A vibrant and wholesome vegetarian take on the classic Bibimbap. This bowl features a colorful array of seasoned vegetables, including spinach, julienned carrots, mushrooms, all artfully arranged over a bed of fluffy white rice. Topped with a perfectly cooked sunny-side-up egg and tofu, served with our signature gochujang sauce for that authentic spicy kick.",
                ShortDescription = "A colorful bowl of rice topped with a fried tofu and variety of seasoned vegetables, a fried egg, and our spicy gochujang sauce.",
                Price = 22m,
                ImageUrl = "",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = alternativeSauceOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup },
                    new ItemOptionGroup { OptionGroup = vegetarianOrVegan }
                }
            };

            var veggieCurry = new Item
            {
                Name = "Vegetarian/Vegan Curry",
                Description = "A hearty and flavorful vegetarian curry featuring a medley of seasonal vegetables simmered in our rich and aromatic Japanese curry sauce. Topped with crispy fried tofu and served over a bed of fluffy Japanese rice, this dish is both satisfying and nourishing.",
                ShortDescription = "A medley of vegetables and tofu in a rich Japanese curry sauce served with fluffy rice.",
                Price = 20m,
                ImageUrl = "",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = extraCurryOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup },
                    new ItemOptionGroup { OptionGroup = vegetarianOrVegan }
                }
            };

            var katsudon = new Item
            {
                Name = "Katsudon",
                Description = "Katsudon is a beloved Japanese dish that perfectly marries contrasting textures and rich flavors. " +
                "Our version features a succulent, thick-cut Tonkatsu pork cutlet, coated in coarse Panko breadcrumbs and" +
                " expertly fried to a beautiful, golden-brown crispness.\r\n\r\nThe magic happens when the crispy cutlet is " +
                "quickly simmered with tender, sweet onions in a traditional dashi broth, flavored with sweet mirin and savory " +
                "soy sauce. It is then finished with a softly cooked, custardy egg that binds the ingredients together." +
                "\r\n\r\nServed over a generous portion of fluffy, warm rice, every spoonful delivers a complex profile:" +
                " the crispness of the cutlet's base, the softness of the egg, and the rich, umami flavor of the broth. " +
                "A truly comforting and classic Japanese experience.",
                ShortDescription = "Crispy breaded pork cutlet simmered with onions and egg in a savory-sweet sauce, served over rice.",
                Price = 20m,
                ImageUrl = "",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = alternativeSauceOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup },
                }
            };

            //Define Bento Box Items

            var veggieBento = new Item
            {
                Name = "Vegetarian/Vegan Bento Box",
                Description = "A thoughtfully curated vegetarian bento box featuring a variety of plant-based delights. This bento includes crispy vegetable spring roll, fluffy rice, fresh salad, and an assortment of pickled vegetables. Accompanied by tofu topped with braised mushroom, it's a balanced and satisfying meal.",
                ShortDescription = "A balanced vegetarian bento box with vegetable tempura, seasoned rice, fresh salad, tofu, and pickled vegetables.",
                Price = 20m,
                ImageUrl = "https://dtfusionzstorage.blob.core.windows.net/menu-images/VeganBento.png",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = vegetarianOrVegan },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup  },
                }
            };

            var tonkatsuPorkBento = new Item
            {
                Name = "Tonkatsu Pork Bento",
                Description = "Our Tonkatsu Pork Bento Box offers a complete and harmonious Japanese lunch experience. The centerpiece is the Tonkatsu: a tender, " +
                "pork loin, lightly seasoned and fried in Panko breadcrumbs to achieve the ultimate crunch, then get drizzled with our signature Tonkatsu " +
                "sauce.\r\n\r\nThis main feature is accompanied " +
                "by a selection of complementary sides designed for perfect balance:\r\n\r\nFluffy Steamed Rice\r\n\r\nA serving of Fresh Salad with a" +
                " light, tangy dressing\r\n\r\nSeasonal Pickles (tsukemono) for a refreshing contrast\r\n\r\nSoba noodles and delicious Fish Tofu " +
                "\r\n\r\nThis bento box is the ideal " +
                "choice for a nutritious, flavorful, and satisfying meal on the go.",
                ShortDescription = "Crispy breaded pork cutlet served with rice, salad, and pickled vegetables.",
                Price = 20m,
                ImageUrl = "https://dtfusionzstorage.blob.core.windows.net/menu-images/TonkatsuPork.png",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = alternativeSauceOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup  },
                }
            };

            var tonkatsuChickenBento = new Item
            {
                Name = "Tonkatsu Chicken Bento",
                Description = "Our Tonkatsu Chicken Bento Box offers a complete and harmonious Japanese lunch experience. The centerpiece is the Tonkatsu: a fresh, " +
                "delicious piece of chicken thigh, lightly seasoned and fried in Panko breadcrumbs to achieve the ultimate crunch, then get drizzled with our signature Tonkatsu " +
                "sauce.\r\n\r\nThis main feature is accompanied " +
                "by a selection of complementary sides designed for perfect balance:\r\n\r\nFluffy Steamed Rice\r\n\r\nA serving of Fresh Salad with a" +
                " light, tangy dressing\r\n\r\nSeasonal Pickles (tsukemono) for a refreshing contrast\r\n\r\nSoba noodles and delicious Fish Tofu " +
                "\r\n\r\nThis bento box is the ideal " +
                "choice for a nutritious, flavorful, and satisfying meal on the go.",
                ShortDescription = "Crispy breaded chicken thigh served with rice, salad, and pickled vegetables.",
                Price = 22m,
                ImageUrl = "https://dtfusionzstorage.blob.core.windows.net/menu-images/TeriyakiChicken.png",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = alternativeSauceOptionGroup },
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup  },
                }
            };

            var chickenTeriyakiBento = new Item
            {
                Name = "Chicken Teriyaki Bento",
                Description = "Indulge in the quintessential flavor of Japanese comfort food with our Chicken Teriyaki Bento. We start with tender cuts of " +
                "chicken, grilled to perfection and generously basted in our homemade signature teriyaki sauce—a balanced blend of soy, mirin, and ginger that " +
                "caramelizes beautifully." +
                "The savory main course is complemented by a carefully selected arrangement of sides, creating a complete and balanced meal in one box:" +
                "\r\n\r\nFluffy Steamed Rice\r\n\r\nA serving of Fresh Salad with a" +
                " light, tangy dressing\r\n\r\nSeasonal Pickles (tsukemono) for a refreshing contrast\r\n\r\nSoba noodles and delicious Fish Tofu " +
                "\r\n\r\n" +
                "This bento box delivers a perfect mix of sweetness, savoriness, and freshness, making it a satisfying choice for any occasion.",
                ShortDescription = "Grilled chicken glazed with teriyaki sauce, served with rice, salad, and pickled vegetables.",
                Price = 22m,
                ImageUrl = "https://dtfusionzstorage.blob.core.windows.net/menu-images/TeriyakiChicken.png",
                IsAvailable = true,
                ItemOptionGroups = new List<ItemOptionGroup>
                {
                    new ItemOptionGroup { OptionGroup = extraMisoOptionGroup  },
                }
            };


            var categories = new[]
            {
                new Category
                {
                    Name = "Rice Bowl",
                    Items = new List<Item>
                    {
                        bibimbap,
                        chickenKatsucurry,
                        grilledFishRiceBowl,
                        veggieBibimbap,
                        veggieCurry,
                        katsudon
                    },
                },

                new Category
                {
                    Name = "Bento Box",
                    Items = new List<Item>
                    {
                        veggieBento,
                        tonkatsuPorkBento,
                        tonkatsuChickenBento,
                        chickenTeriyakiBento
                    },
                },

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