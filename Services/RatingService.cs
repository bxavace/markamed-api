using markamed_api.Interfaces.IService;
using markamed_api.Models.Dto;

namespace markamed_api.Services
{
    public class RatingService : IRatingService
    {
        Task<RatingDto> IRatingService.CreateAsync(RatingDto ratingDto)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<RatingDto>> IRatingService.GetByFacilityIdAsync(int facilityId)
        {
            throw new NotImplementedException();
        }
    }
}