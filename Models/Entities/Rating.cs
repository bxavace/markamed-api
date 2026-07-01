namespace markamed_api.Models.Entities
{
    public class Rating : EntityBase
    {
        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public int RatingAttributeId { get; set; }
        public int RatingDepartmentId { get; set; }
        public string? Review { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Facility Facility { get; set; } = null!;
        public virtual RatingAttribute RatingAttribute { get; set; } = null!;
        public virtual RatingDepartment RatingDepartment { get; set; } = null!;
        public virtual ICollection<RatingFeedback> RatingFeedbacks { get; set; }
    }
}