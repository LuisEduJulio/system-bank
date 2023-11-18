using api_bank.domain.Entities;

namespace api_bank.domain.ModelView.BankModelView
{
    public class GetBankModelView
    {
        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public List<ExtractEntity> ExtractEntitys { get; set; }
        public List<CustomerEntity> CustomerEntitys { get; set; }
    }
}
