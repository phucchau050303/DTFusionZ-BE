using Microsoft.AspNetCore.Mvc;
using DTFusionZ_BE.Services;

namespace DTFusionZ_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly StripeService _stripeService;

        public PaymentController(StripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment()
        {
            try
            {
                var paymentIntent = await _stripeService.CreatePaymentIntentAsync(1000); // $10.00
                return Ok(new { ClientSecret = paymentIntent.ClientSecret });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}