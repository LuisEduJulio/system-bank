using api_bank.domain.Enums;

namespace api_bank.domain.Dtos
{
    public class UpdateExtractDto
    {
        public int Id { get; set; }
        public string Describe { get; set; }
        public decimal Price { get; set; }
        public string Loose { get; set; }
        public EExtractType EExtractType { get; set; }
    }
}
