using api_bank.domain.Entities;

namespace api_bank.domain.ModelView.CustomerModelView
{
    public class GetCustomerModelView
    {
        public GetCustomerModelView()
        {
            ExtractEntitys = new List<ExtractEntity>();
        }
        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BankEntityId { get; set; }
        public BankEntity BankEntity { get; set; }
        public List<ExtractEntity> ExtractEntitys { get; set; }
    }
}
