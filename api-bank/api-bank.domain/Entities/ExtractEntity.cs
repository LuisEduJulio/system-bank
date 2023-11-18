using api_bank.domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_bank.domain.Entities
{
    public class ExtractEntity : BaseEntity
    {
        public string Describe { get; set; }
        public decimal Price { get; set; }
        public string Loose { get; set; }
        public EExtractType EExtractType { get; set; }
        public int CustomerEntityId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CustomerEntity CustomerEntity { get; set; }
        public int BankEntityId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual BankEntity BankEntity { get; set; }
    }
}
