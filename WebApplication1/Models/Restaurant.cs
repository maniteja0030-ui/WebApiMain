namespace WebApplication1.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public double Rating { get; set; }

        public int DeliveryTime { get; set; }

        public ICollection<MenuItem>? MenuItems { get; set; }

        public ICollection<Order>? Orders { get; set; }   // optional but recommended
    }
}