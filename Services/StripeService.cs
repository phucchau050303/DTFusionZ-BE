using Stripe;
using Microsoft.Extensions.Options;
using DTFusionZ_BE.Config;
using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;

namespace DTFusionZ_BE.Services
{
    public class StripeService
    {
        private readonly StripeSettings _stripeSettings;
        private readonly ApplicationDbContext _context;

        public StripeService(IOptions<StripeSettings> stripeSettings, ApplicationDbContext context)
        {
            _stripeSettings = stripeSettings.Value;
            _context = context;
        }

        public async Task SyncProductsWithStripe()
        {
            var items = await _context.Items
                .Where(i => i.DeletedAt == null)
                .ToListAsync();

            foreach (var item in items)
            {
                var productOptions = new ProductCreateOptions
                {
                    Name = item.Name,
                    Description = item.Description,
                    Images = new List<string> { item.ImageUrl },
                    Metadata = new Dictionary<string, string>
                    {
                        { "ItemId", item.Id.ToString() }
                    }
                };

                var productService = new ProductService();
                var product = await productService.CreateAsync(productOptions);

                var priceOptions = new PriceCreateOptions
                {
                    Product = product.Id,
                    UnitAmount = (long)(item.Price * 100), // Convert to cents
                    Currency = "aud"
                };

                var priceService = new PriceService();
                var price = await priceService.CreateAsync(priceOptions);
            }
        }

        public async Task<PaymentIntent> CreatePaymentIntentAsync(long amount, string currency = "aud")
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }
    }
}