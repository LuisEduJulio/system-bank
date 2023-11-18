namespace api_bank.domain.ModelView.CustomerModelView
{
    public class AddCustomerModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BankEntityId { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}