using ezBuy.DAO.Layer.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBuy.AppContext;
using EzBuy.Models;
using Microsoft.EntityFrameworkCore;
using EzBuy.Interfaces;

namespace ezBuy.DAO.Layer
{
    public class UserRepository : EFCoreRepository<User, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}
