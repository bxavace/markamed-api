namespace markamed_api.Models.Dto
{
    public class RatingDto
    {   
        public int UserId { get; set; }
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public int FacilityId { get; set; }
        public string FacilityCode { get; set; } = null!;
        public string FacilityName { get; set; } = null!;
        public int? OverallScore { get; set; }
        public string? Review { get; set; }
        public List<RatingAttributeItemDto> RatingAttributeItems { get; set; }
        public List<RatingDepartmentItemDto> RatingDepartmentItems { get; set; }
    }
}