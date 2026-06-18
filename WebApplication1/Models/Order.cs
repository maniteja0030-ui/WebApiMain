namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string DeliveryAddress { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        // 👇 NEW: User (customer)
        public int UserId { get; set; }

        // 👇 NEW: Restaurant FK
        public int RestaurantId { get; set; }

        // 👇 Navigation property (IMPORTANT)
        public Restaurant? Restaurant { get; set; }

        // 👇 Navigation property
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}