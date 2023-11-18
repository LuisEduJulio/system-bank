using api_bank.domain.Entities;
using api_bank.domain.Enums;

namespace api_bank.domain.ModelView.ExtractModelView
{
    public class AddExtractModelView
    {
        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public string Describe { get; set; }
        public decimal Price { get; set; }
        public string Loose { get; set; }
        public EExtractType EExtractType { get; set; }
        public int CustomerEntityId { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public int BankEntityId { get; set; }
        public virtual BankEntity BankEntity { get; set; }
    }
}
