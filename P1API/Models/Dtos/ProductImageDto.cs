using P1API.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace P1API.Models.Dtos
{
    public class ProductImageDto
    {
        public int ProductId { get; set; }
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
