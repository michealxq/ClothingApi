using P1API.Models.Domains;
using static System.Net.Mime.MediaTypeNames;

namespace P1API.Repositories
{
    public interface IProductImageRepository
    {
        
        Task<ProductImage> Upload(ProductImage productImage);
        Task<ProductImage> GetByIDAsync(int id);
        Task<List<ProductImage>> GetAllAsync();
    }
}
