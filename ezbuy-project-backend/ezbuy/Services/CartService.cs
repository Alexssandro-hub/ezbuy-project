using ezbuy.Models.DTOs.Request;
using ezbuy.Repos.Interfaces;
using ezbuy.Services.Interfaces;

namespace ezbuy.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;

        public CartService(ICartRepository cartRepo, IOrderRepository orderRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsByUserAsync(int userId)
        {
            var cartItems = await _cartRepo.GetCartItemsByUserAsync(userId);
            return cartItems.Select(ci => new CartItemDto
            {
                ProductId = ci.ProductId,
                ProductName = ci.Product.Name,
                Quantity = ci.Quantity,
                Price = ci.Product.Price
            });
        }

        public async Task AddItemToCartAsync(AddCartItemDto dto)
        {
            await _cartRepo.AddItemAsync(dto.UserId, dto.ProductId, dto.Quantity);
        }

        public async Task RemoveItemFromCartAsync(RemoveCartItemDto dto)
        {
            await _cartRepo.RemoveItemAsync(dto.UserId, dto.ProductId);
        }

        public async Task<int> CheckoutAsync(int userId)
        {
            var cartItems = await _cartRepo.GetCartItemsByUserAsync(userId);
            if (!cartItems.Any()) throw new Exception("Carrinho vazio.");

            var orderId = await _orderRepo.CreateOrderAsync(userId, cartItems);
            await _cartRepo.ClearCartAsync(userId);

            return orderId;
        }
    }

}
