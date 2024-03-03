using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzCoreBusiness.Interfaces;
using EzDomain.DbContext;
using EzDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EzCoreBusiness.Services
{
    public class UserService<TContext> : IUserService where TContext : AppDbContext
    {
        private readonly TContext _db;
        public UserService(TContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAll(bool? isActive)
        {
            if (isActive == null) { return await _db.Users.ToListAsync(); }

            return await _db.Users.Where(obj => obj.IsActive == isActive).ToListAsync();
        }

        public async Task<User?> GetByID(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> Add(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                LastName = user.LastName,
                IsActive = user.IsActive,
            };

            _db.Users.Add(newUser);
            var result = await _db.SaveChangesAsync();

            return result >= 0 ? newUser : null;
        }

        public async Task<User?> Update(int id, User user)
        {
            var userDb = await _db.Users.FirstOrDefaultAsync(index => index.Id == id);
            if (userDb != null)
            {
                userDb.Name = user.Name;
                userDb.LastName = user.LastName;
                userDb.IsActive = user.IsActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? userDb : null;
            }
            return null;
        }

        public async Task<bool> DeleteByID(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(index => index.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
