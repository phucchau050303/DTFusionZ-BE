using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Models.DTOs;

namespace DTFusionZ_BE.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DTFusionZDbContext _context;

        public OrderController(DTFusionZDbContext context)
        {
            _context = context;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderCreateDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = new Order
            {
                CustomerName = orderDto.CustomerName,
                CustomerPhone = orderDto.CustomerPhone,
                CustomerEmail = orderDto.CustomerEmail,
                OrderType = orderDto.OrderType,
                Status = "New",
                OrderDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };

            //Create OrderItems
            foreach (var itemDto in orderDto.Items)
            {
                var item = await _context.Items.FindAsync(itemDto.ItemId);
                if (item == null)
                {
                    return BadRequest($"Item with ID {itemDto.ItemId} not found.");
                }
                var orderItem = new OrderItem
                {
                    ItemId = itemDto.ItemId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = itemDto.UnitPrice,
                    SpecialInstructions = itemDto.SpecialInstructions,
                    CreatedAt = DateTime.UtcNow
                };

                //Create OrderItemOptions
                foreach (var optionDto in itemDto.Options)
                {
                    var optionValue = await _context.OptionValues.FindAsync(optionDto.OptionValueId);
                    if (optionValue == null)
                    {
                        return BadRequest($"OptionValue with ID {optionDto.OptionValueId} not found.");
                    }

                    orderItem.OrderItemOptions.Add(new OrderItemOption
                    {
                        OptionValueId = optionDto.OptionValueId,
                        PriceModifier = optionValue.PriceModifier,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                orderItem.TotalPrice = (orderItem.UnitPrice + orderItem.OrderItemOptions.Sum(oio => oio.PriceModifier)) * orderItem.Quantity;
                order.OrderItems.Add(orderItem);
            }

            order.OrderTotal = order.OrderItems.Sum(oi => oi.TotalPrice);    

            try 
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.OrderItemOptions)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        //PUT: api/orders/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatusUpdateDto statusDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.Status = statusDto.Status;
            order.UpdatedAt = DateTime.UtcNow;

            try 
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        //GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.OrderItemOptions)
            .ToListAsync();
        }

        //Delete: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.OrderItemOptions)
            .FirstOrDefaultAsync(o => o.Id == id);


            if (order == null)
            {
                return NotFound();
            }
            
            var utcNow = DateTime.UtcNow;

            order.DeletedAt = utcNow;
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.DeletedAt = utcNow;
                foreach (var orderItemOption in orderItem.OrderItemOptions)
                {
                    orderItemOption.DeletedAt = utcNow;
                }
            }

            try 
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}