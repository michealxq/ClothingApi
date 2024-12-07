using P1API.Models.Domains;

namespace P1API.Models.Dtos
{
    public class UpdateOrderItemRequestDto
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; } // Price at the time of order
        
    }
}
