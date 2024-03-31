using ezbuy.Data;
using ezbuy.Models.DTOs.Request;
using ezbuy.Models;
using ezbuy.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ezbuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenService _tokenService;
        public ProductController(DataContext context, IHttpContextAccessor httpContextAccessor,
            TokenService tokenService, ILogger<ProductController> logger)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            =>
                Ok(await _context.Products.Where(u => u.Id > 0).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            =>
                Ok(await _context.Products.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync());

        [HttpPost]
        public async Task<IActionResult> Register(Product productRequest)
        {
            if (productRequest is null)
                return BadRequest("Não foi possível cadastrar produto");

            try
            {
                var userId = GetUserId();
                var product = new Product
                {
                    Id = 0, 
                    Category = productRequest.Category,
                    Name = productRequest.Name,
                    Description = productRequest.Description,
                    Price = productRequest.Price, 
                    CreateDate = DateTime.Now,
                    CreatedUserId = userId == 0 ? 1 : userId //1: Admin.
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product productRequest)
        {
            try
            {
                var product = await _context.Products.Where(x => x.Id.Equals(productRequest.Id)).FirstOrDefaultAsync(); 
                if (product is null) return BadRequest("Produto não encontrado!");

                var userId = GetUserId();

                product.Name = productRequest.Name;
                product.Description = productRequest.Description;
                product.Category = productRequest.Category;
                product.Price = productRequest.Price;
                product.UpdatedDate = DateTime.Now;
                product.UpdatedUserId = userId == 0 ? 1 : userId; //1: Admin.

                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _context.Products.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync(); 
                if (product is null) return BadRequest("Produto não encontrado!");

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #region  UserRegion

        private int GetUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                var user = httpContext.User;

                if (user != null)
                { 
                    string userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    return Convert.ToInt32(userId);
                }
            }

            return 0;
        }

        #endregion
    }
}
