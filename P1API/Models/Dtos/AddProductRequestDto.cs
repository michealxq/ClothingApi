using P1API.Models.Domains;

namespace P1API.Models.Dtos
{
    public class AddProductRequestDto
    {
        
        public string ProductName { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        
    }
}
