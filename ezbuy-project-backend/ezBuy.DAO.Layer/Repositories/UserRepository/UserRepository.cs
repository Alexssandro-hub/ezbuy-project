using ezBuy.DAO.Layer.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.DTOs.Requests;
using EzBuy.AppContext; 
using EzBuy.Models;
using Microsoft.EntityFrameworkCore;
using EzBuy.Interfaces; 

namespace ezBuy.DAO.Layer.Repositories.UserRepository
{
    public class UserRepository<T> : EFCoreRepository<User, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
          
        public async Task<User> GetUser(LoginRequest loginRequest)
        {
            return await _context.Users.Where(x => x.Email.Equals(loginRequest.Email) &&x.Password.Equals(loginRequest.Password))
                                       .SingleOrDefaultAsync();
        }

    }
}
