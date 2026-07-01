namespace markamed_api.Models.Entities
{
    public class Rating : EntityBase
    {
        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public string? Review { get; set; }
        public int? OverallScore { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Facility Facility { get; set; } = null!;
        public virtual ICollection<RatingAttributeItem> RatingAttributeItems { get; set; } = null!;
        public virtual ICollection<RatingDepartmentItem> RatingDepartmentItems { get; set; } = null!;
        public virtual ICollection<RatingFeedback> RatingFeedbacks { get; set; }
    }
}