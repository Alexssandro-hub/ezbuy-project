using ezBuy.Abstractions.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzBuy.Models;

[Table(nameof(User), Schema = "root_schema")] // if entity is childschema, set Schema: child_schemaName
public class User : IDataEntity
{
    [Key]
    public int Id { get; set; }
    public static string Name { get; set; } = string.Empty;
    public static string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = Name + " " + LastName;
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public Tenant Tenant { get; set; }
    public int TenantId { get; set; }
    public Group Group { get; set; }
    public int GroupId { get; set; }
    public Rule Rule { get; set; }
    public int RuleId { get; set; }
}