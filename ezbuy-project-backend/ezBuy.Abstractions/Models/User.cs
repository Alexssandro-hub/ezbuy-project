using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzBuy.Models;

[Table(nameof(User), Schema = "root_schema")] // if entity is childschema, set Schema: child_schemaName
public class User : IDataEntity
{
    [Key]
    public int Id { get; set; }
    public  string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public bool IsActive { get; set; } 
}