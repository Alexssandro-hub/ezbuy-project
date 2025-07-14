using ezbuy.Data;
using ezbuy.Models;
using ezbuy.Models.DTOs.Request;
using ezbuy.Services;
using ezbuy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ezbuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context, IEncryptPassService encryptPassService, ITokenService tokenService, ILogger<UserController> logger) : ControllerBase
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
            var user = await context.Users.FirstOrDefaultAsync(
                u => u.Email.ToUpper().Equals(login.Email.ToUpper()));

            if (user is not null &&
                encryptPassService.VerifyPassword(login.Password, user.Password))
            {
                var accessToken = tokenService.CreateToken(user);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    UserId = user.Id,
                    Username = user.FirstName,
                    Email = user.Email,
                    Token = accessToken
                });
            }
             
            return BadRequest("Usuário não cadastrado/encontrado!");
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
                    Login = userRequest.Login,
                    FirstName = userRequest.FirstName,
                    LastName = userRequest.LastName,
                    Email = userRequest.Email,
                    Password = encryptPassService.Encrypt(userRequest.Password),
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

        [HttpPut("edit")]
        public async Task<IActionResult> UpdateUser(UserRequest userRequest)
        { 
            try
            {
                var user = await context.Users.Where(x => x.Id.Equals(userRequest.Id)).FirstOrDefaultAsync();

                if (user is null) return BadRequest("Usuário inexistente!");

                user.FirstName = userRequest.FirstName;
                user.LastName = userRequest.LastName;
                user.Email = userRequest.Email;
                user.Password = encryptPassService.Encrypt(userRequest.Password);
                 
                await context.SaveChangesAsync();
                return Ok(user);
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
                var user = await context.Users.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

                if (user is null) return BadRequest("Usuário não encontrado!");

                context.Users.Remove(user);
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
