using ezBuy.Domain.Models.AbstactEntities;

namespace ezBuy.Domain.Models
{
    public class User : IDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime DateBirth { get; set; }
        public string CpfOrCnpj { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime InactiveDate { get; set; }
    }
}
