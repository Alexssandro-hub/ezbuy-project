using ezbuy.Models;

namespace ezbuy.Repos.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(int userId, List<CartItem> cartItems);
        Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
