using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Domain.Models;

namespace ezBuy.Domain.Comparers
{
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (ReferenceEquals(x, y)) 
                return true;

            if (x is null || y is null || x.GetType() != y.GetType()) 
                return false;

            return x.Id == y.Id && 
                   x.Name == y.Name && 
                   x.DateBirth.Equals(y.DateBirth) && 
                   x.CpfOrCnpj == y.CpfOrCnpj && 
                   x.Email == y.Email && 
                   x.CreateDate.Equals(y.CreateDate) && 
                   x.UpdateDate.Equals(y.UpdateDate) && 
                   x.InactiveDate.Equals(y.InactiveDate);
        }

        public int GetHashCode(User obj)
        {
            return HashCode.Combine(
                obj.Id, 
                obj.Name, 
                obj.DateBirth, 
                obj.CpfOrCnpj, 
                obj.Email, 
                obj.CreateDate, 
                obj.UpdateDate, 
                obj.InactiveDate);
        }
    }
}
