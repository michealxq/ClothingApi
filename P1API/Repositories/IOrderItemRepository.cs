﻿using P1API.Models.Domains;

namespace P1API.Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync();
        Task<OrderItem?> GetByIdAsync(int id);
        Task<OrderItem> CreateAsync(OrderItem orderItem);
        Task<OrderItem?> UpdateAsync(int id, OrderItem orderItem);
        Task<OrderItem?> DeleteAsync(int id);
    }
}
