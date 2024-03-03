using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.DTOs.Requests;
using ezBuy.Business.Layer.Services;
using ezBuy.Business.Layer.Services.Custom;
using EzBuy.AppContext;
using ezBuy.DAO.Layer.Repositories.UserRepository;
using EzBuy.Interfaces;
using EzBuy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ezBuy.Controllers.Layer.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly EncryptPassService _encryptPassService;
       //private readonly UserReadRepository _userReadRepository;

        public IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public LoginController(
            LoginService loginService,
            IConfiguration config,
            EncryptPassService encryptPassService,
            ApplicationDbContext context
           // UserReadRepository userReadRepository
        )
        {
            _loginService = loginService;
            _configuration = config;

            _context = context;
            _encryptPassService = encryptPassService; 
            //_userReadRepository = new UserReadRepository(context);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                //var user = await _userReadRepository.GetUser(_userData);

                //if (user is null) return BadRequest("Invalid credentials");

                //var claims = new[] {
                //    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                //    new Claim("UserId", user.Id.ToString()),
                //    new Claim("DisplayName", user.Name),
                //    new Claim("UserName", user.UserName),
                //    new Claim("Email", user.Email)
                //};

                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //var token = new JwtSecurityToken(
                //    _configuration["Jwt:Issuer"],
                //    _configuration["Jwt:Audience"],
                //    claims,
                //    expires: DateTime.UtcNow.AddMinutes(10),
                //    signingCredentials: signIn);

                //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest("Invalid credentials");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterRequest userRegister)
        {
            if (userRegister is null)
            {
                return BadRequest("Dados de usuários não foram enviados");
            }

            var createdEntity = await _loginService.Register(userRegister);

            if (createdEntity is not null) return Ok();

            return BadRequest(_loginService.Errors);
        }

        [HttpPost("reset-pass")]
        public async Task<IActionResult> ResetPass()
        {
            return Ok();
        }

        //public async Task<User> GetUser(LoginRequest loginRequest)
        //    => await _context.Users
        //        .Where(x => x.Email.Equals(loginRequest.Email) && x.Password.Equals(loginRequest.Password))
        //        .FirstOrDefaultAsync() ?? new User();
    }
}
