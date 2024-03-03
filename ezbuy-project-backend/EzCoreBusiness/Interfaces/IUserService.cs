using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzDomain.Entities;

namespace EzCoreBusiness.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll(bool? isActive);
        Task<User?> GetByID(int id);
        Task<User?> Add(User user);
        Task<User?> Update(int id, User user);
        Task<bool> DeleteByID(int id);
    }
}
