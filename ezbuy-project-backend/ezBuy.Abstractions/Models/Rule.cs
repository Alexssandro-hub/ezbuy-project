using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBuy.Models;

namespace ezBuy.Abstractions.Models
{
    [Table(nameof(Rule), Schema = "root_schema")]
    public class Rule : IDataEntity
    {
        [Key]
        public int Id { get; set; }
        public string Responsibility { get; set; } = string.Empty;
        public User User { get; set; }
        public int UserId { get; set; }
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }

    }
}
