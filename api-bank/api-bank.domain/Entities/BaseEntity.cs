namespace api_bank.domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDisabled { get; set; }
    }
}