using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_bank.domain.Entities
{
    public class BankEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual List<ExtractEntity> ExtractEntitys { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual List<CustomerEntity> CustomerEntitys { get; set; }
    }
}
