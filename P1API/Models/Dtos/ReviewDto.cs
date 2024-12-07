using P1API.Models.Domains;

namespace P1API.Models.Dtos
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        
        
        public string Comment { get; set; }
        public int Rating { get; set; } // e.g., 1 to 5 stars
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
}
