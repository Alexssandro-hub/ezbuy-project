using EzBuy.Extensions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ezBuy.Abstractions.Models;

namespace EzBuy.Models
{
    [Table(nameof(Tenant), Schema = "root_schema")]
    public class Tenant : IDataEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TenantType Type { get; set; } 
        public string Database { get; set; } = string.Empty;
        public string Server { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        //public User User { get; set; }
        //public Group Group { get; set; }
        //public int? GroupId { get; set; }
        //public Rule Rule { get; set; }
        //public int? RuleId { get; set; }
        //public int UserId { get; set; }
    }
}
