using ezBuy.Business.Layer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.DTOs.Requests;
using EzBuy.AppContext;
using EzBuy.Models;
using ezBuy.DAO.Layer.Repositories.UserRepository;

namespace ezBuy.Business.Layer.Services
{
    public class UserService : IUserService<User, LoginRequest>
    { 
        public UserService()
        {
            //_userRepository = userRepository;
        }
        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
         
        public async Task<User> GetUser(LoginRequest loginRequest)
        {
            //return await _userRepository.GetUser(loginRequest);
            throw new NotImplementedException();
        }
    }
}
