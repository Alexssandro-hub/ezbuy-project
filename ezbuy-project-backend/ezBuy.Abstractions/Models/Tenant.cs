using EzBuy.Extensions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzBuy.Models
{
    [Table(nameof(Tenant), Schema = "root_schema")]
    public class Tenant : IDataEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TenantType Type { get; set; } 
        public string Database { get; set; }
        public string Server { get; set; }
        public string Domain { get; set; }
        public string Port { get; set; }
        public bool IsActive { get; set; }
    }
}
