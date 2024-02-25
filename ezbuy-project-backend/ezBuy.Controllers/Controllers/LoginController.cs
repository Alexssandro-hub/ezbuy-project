using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.DTOs.Requests;
using ezBuy.Business.Layer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ezBuy.Controllers.Layer.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(
            LoginService loginService
        )
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterRequest userRegister)
        {
            if (userRegister is null)
            {
                return BadRequest("Dados de usuários não foram enviados");
            }

            var createdEntity = await _loginService.Register(userRegister);

            if (createdEntity is not null) return Ok();

            return BadRequest("Usuário não cadastrado");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPass()
        {
            return Ok();
        }
    }
}
