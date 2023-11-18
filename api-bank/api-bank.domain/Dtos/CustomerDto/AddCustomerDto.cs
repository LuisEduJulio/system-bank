namespace api_bank.domain.Dtos.CustomerDto
{
    public class AddCustomerDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BankEntityId { get; set; }
    }
}
