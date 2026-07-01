namespace markamed_api.Models.Entities
{
    public class RatingDepartmentItem : EntityBase
    {
        public int RatingId { get; set; }
        public int RatingDepartmentId { get; set; }
        // Should be between 1 and 5, inclusive
        public int Score { get; set; }

        // Navigation properties
        public virtual Rating Rating { get; set; } = null!;
    }
}