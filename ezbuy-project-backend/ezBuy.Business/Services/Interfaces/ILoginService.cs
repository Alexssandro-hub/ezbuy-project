using ezBuy.Abstractions.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ezBuy.Business.Layer.Services.Interfaces
{
    internal interface ILoginService<T, TRequest> where T : class
    {
        public Task<TRequest> Register(UserRegisterRequest userRegister);
        public Task<T> Login(LoginRequest login);
    }
}
