using P1API.Models.Domains;

namespace P1API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(int id, User user);
        Task<User?> DeleteAsync(int id);
    }
}
