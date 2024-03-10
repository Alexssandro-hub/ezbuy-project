using ezbuy.Data;
using ezbuy.Models;
using ezbuy.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ezbuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
            => 
                Ok(await context.Users.Where(u => u.Id > 0).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
            => 
                Ok(await context.Users.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync());

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password.Equals(login.Password));

            if (user is not null) return Ok(user);

            return BadRequest("Usuário não cadastrado!");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRequest? userRequest)
        {
            if (userRequest is null) 
                return BadRequest("Não foi possível cadastrar usuário");

            try
            {
                var user = new User
                {
                    Id = 0,
                    FirstName = userRequest.FirstName,
                    LastName = userRequest.LastName,
                    Email = userRequest.Email,
                    Password = userRequest.Password,
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex);
            }
        }
    }
}
