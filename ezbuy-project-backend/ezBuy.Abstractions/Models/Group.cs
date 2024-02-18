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
    [Table(nameof(Group), Schema = "root_schema")]
    public class Group : IDataEntity
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
    }
}
