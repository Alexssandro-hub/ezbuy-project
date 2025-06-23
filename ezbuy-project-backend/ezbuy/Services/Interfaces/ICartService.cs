using ezbuy.Models.DTOs.Request;

namespace ezbuy.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDto>> GetCartItemsByUserAsync(int userId);
        Task AddItemToCartAsync(AddCartItemDto dto);
        Task RemoveItemFromCartAsync(RemoveCartItemDto dto);
        Task<int> CheckoutAsync(int userId);
    }
}
