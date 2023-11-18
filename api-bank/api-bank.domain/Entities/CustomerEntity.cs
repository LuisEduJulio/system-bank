using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_bank.domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BankEntityId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual BankEntity BankEntity { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual List<ExtractEntity>? ExtractEntitys { get; set; }
    }
}
