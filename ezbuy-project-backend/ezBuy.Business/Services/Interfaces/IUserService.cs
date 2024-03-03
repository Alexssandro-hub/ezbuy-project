using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.DTOs.Requests;
using EzBuy.Models;

namespace ezBuy.Business.Layer.Services.Interfaces
{
    public interface IUserService<T, TRequest> where T : class
    {
        public Task<T> GetById(int id);
        public Task<T> GetUser(TRequest loginRequest);
    }
}
