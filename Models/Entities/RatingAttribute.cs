namespace markamed_api.Models.Entities
{
    public class RatingAttribute : EntityBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        // Navigation properties
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}