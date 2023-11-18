namespace api_bank.domain.Dtos
{
    public class PaginationDto
    {
        public PaginationDto(int page, int count)
        {
            Page = page;
            Count = count;
        }
        public int Page { get; set; }
        public int Count { get; set; }
    }
}