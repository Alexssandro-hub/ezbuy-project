using ezbuy.Models;

namespace ezbuy.Repos.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetCartItemsByUserAsync(int userId);
        Task AddItemAsync(int userId, int productId, int quantity);
        Task RemoveItemAsync(int userId, int productId);
        Task ClearCartAsync(int userId);
    }
}
