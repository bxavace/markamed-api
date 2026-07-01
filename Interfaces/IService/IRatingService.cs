using markamed_api.Models.Dto;

namespace markamed_api.Interfaces.IService
{
    public interface IRatingService
    {
        Task<RatingDto> CreateAsync(RatingDto ratingDto);
        Task<IReadOnlyList<RatingDto>> GetByFacilityIdAsync(int facilityId);
    }
}