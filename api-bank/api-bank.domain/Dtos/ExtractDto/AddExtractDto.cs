namespace api_bank.domain.Dtos
{
    public class AddExtractDto
    {
        public string Describe { get; set; }
        public decimal Price { get; set; }
        public string Loose { get; set; }
        public int CustomerEntityId { get; set; }
        public int BankEntityId { get; set; }
    }
}