using ezbuy.Models.DTOs.Request;
using ezbuy.Services.Interfaces; 
using Microsoft.AspNetCore.Mvc;

namespace ezbuy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            var items = await _cartService.GetCartItemsByUserAsync(userId);
            return Ok(items);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItemToCart([FromBody] AddCartItemDto dto)
        {
            await _cartService.AddItemToCartAsync(dto);
            return Ok();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveItemFromCart([FromBody] RemoveCartItemDto dto)
        {
            await _cartService.RemoveItemFromCartAsync(dto);
            return Ok();
        }

        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout(int userId)
        {
            var orderId = await _cartService.CheckoutAsync(userId);
            return Ok(new { orderId });
        }
    }
}
