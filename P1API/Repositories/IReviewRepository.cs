using P1API.Models.Domains;

namespace P1API.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task<Review> CreateAsync(Review review);
        Task<Review?> UpdateAsync(int id, Review review);
        Task<Review?> DeleteAsync(int id);
    }
}
