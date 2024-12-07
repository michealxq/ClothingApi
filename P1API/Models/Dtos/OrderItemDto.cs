using P1API.Models.Domains;

namespace P1API.Models.Dtos
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        
      
        public int Quantity { get; set; }
        public decimal? Price { get; set; } // Price at the time of order
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
