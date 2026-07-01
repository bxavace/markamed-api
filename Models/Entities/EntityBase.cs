namespace markamed_api.Models.Entities
{
    public class EntityBase
    {
        public int Id { get; set;}
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string DeletedBy { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}