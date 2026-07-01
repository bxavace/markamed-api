namespace markamed_api.Models.Dto
{
    public class RatingAttributeItemDto
    {
        public int RatingAttributeId { get; set; }
        public string RatingAttributeName { get; set; } = null!;
        public int Score { get; set; }
    }
}