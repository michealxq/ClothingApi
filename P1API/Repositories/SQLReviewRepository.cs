using Microsoft.EntityFrameworkCore;
using P1API.Data;
using P1API.Models.Domains;

namespace P1API.Repositories
{
    public class SQLReviewRepository : IReviewRepository
    {
        private readonly ClothingDbContext dbContext;

        public SQLReviewRepository(ClothingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Review> CreateAsync(Review review)
        {
            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();

            return review;
        }

        public async Task<Review?> DeleteAsync(int id)
        {
            var existing = await dbContext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Reviews.Remove(existing);
            dbContext.SaveChanges();
            return existing;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await dbContext.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            var existing = await dbContext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
            if (existing == null)
            {
                return null;
            }
            return existing;
        }

        public async Task<Review?> UpdateAsync(int id, Review review)
        {
            var existing = await dbContext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
            if (existing == null)
            {
                return null;
            }
            
            existing.ProductId=review.ProductId;
            existing.UserId = review.UserId;
            existing.Comment=review.Comment;
            existing.Rating=review.Rating;
            existing.CreatedAt=review.CreatedAt;

            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
