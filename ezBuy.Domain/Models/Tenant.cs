using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Domain.Models.AbstactEntities;

namespace ezBuy.Domain.Models
{
    public class Tenant : IDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionDomain { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public int UserId { get; set; }
        public string UserAccess { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsRootSchema { get; set; } 
    }
}
