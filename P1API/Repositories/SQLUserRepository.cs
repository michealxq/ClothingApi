using P1API.Data;
using P1API.Models.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace P1API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ClothingDbContext dbContext;

        public SQLUserRepository(ClothingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var existing = await dbContext.Users.FirstOrDefaultAsync( x => x.UserId == id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Users.Remove(existing);
            dbContext.SaveChanges();
            return existing;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
            
               
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var existing = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existing == null)
            {
                return null;
            }
            return existing;
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existing = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existing == null)
            {
                return null;
            }
            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.Email = user.Email;
            existing.PasswordHash = user.PasswordHash;
            existing.Role = user.Role;
            existing.CreatedAt = user.CreatedAt;
            
            await dbContext.SaveChangesAsync();
            return existing;

        }
    }
}
