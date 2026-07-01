namespace markamed_api.Models.Entities
{
    public class RatingFeedback : EntityBase
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public byte IsHelpful { get; set; }

        // Navigation properties
        public virtual Rating Rating { get; set; } = null!;
    }
}