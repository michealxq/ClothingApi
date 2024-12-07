namespace P1API.Models.Domains
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public float TotalAmount { get; set; }
        public string OrderStatus { get; set; } = "Pending"; // e.g., Pending, Shipped, Completed
        public User User { get; set; }
        
    }
}
