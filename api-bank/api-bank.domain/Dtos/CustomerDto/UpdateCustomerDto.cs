namespace api_bank.domain.Dtos.CustomerDto
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BankEntityId { get; set; }
    }
}
