namespace WebApplication1.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

        // Foreign Key
        public int RestaurantId { get; set; }

        // Navigation Property
        public Restaurant? Restaurant { get; set; }
    }
}