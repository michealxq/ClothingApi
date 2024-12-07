using P1API.Models.Domains;

namespace P1API.Models.Dtos
{
    public class UpdateOrderRequestDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public float TotalAmount { get; set; }
        public string OrderStatus { get; set; } = "Pending"; // e.g., Pending, Shipped, Completed
        
    }
}
