using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ORDERS (FILTER BY USER OR RESTAURANT)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int? userId, int? restaurantId)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems!)
                .ThenInclude(oi => oi.MenuItem)
                .AsQueryable();

            if (userId != null)
                query = query.Where(o => o.UserId == userId);

            if (restaurantId != null)
                query = query.Where(o => o.RestaurantId == restaurantId);

            return await query.ToListAsync();
        }

        // CREATE ORDER (USER)
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            decimal totalAmount = 0;

            foreach (var item in order.OrderItems!)
            {
                var menuItem = await _context.MenuItems.FindAsync(item.MenuItemId);

                if (menuItem == null)
                    return BadRequest($"MenuItem {item.MenuItemId} not found");

                // ensure same restaurant
                if (menuItem.RestaurantId != order.RestaurantId)
                    return BadRequest("All items must belong to same restaurant");

                item.Price = menuItem.Price;
                totalAmount += item.Price * item.Quantity;
            }

            order.TotalAmount = totalAmount;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}