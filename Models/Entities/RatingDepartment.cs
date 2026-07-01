namespace markamed_api.Models.Entities
{
    public class RatingDepartment : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}