using P1API.Models.Domains;

namespace P1API.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<Order?> UpdateAsync(int id, Order order);
        Task<Order?> DeleteAsync(int id);
    }
}
