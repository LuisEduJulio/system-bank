using api_bank.domain.Enums;

namespace api_bank.domain.Dtos
{
    public class FilterExtractDto
    {
        public int Id { get; set; }
        public string? Describe { get; set; }
        public EExtractType? EExtractType { get; set; }
        public int CustomerEntityId { get; set; }
        public int BankEntityId { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
