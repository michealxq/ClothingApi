using P1API.Models.Domains;

namespace P1API.Models.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
