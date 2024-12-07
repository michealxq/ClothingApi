using System.ComponentModel.DataAnnotations.Schema;

namespace P1API.Models.Domains
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }
    }
}
