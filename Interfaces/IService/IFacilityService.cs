using markamed_api.Models.Dto;
using markamed_api.QueryParameters;

namespace markamed_api.Interfaces.IService
{
    public interface IFacilityService
    {
        Task<FacilityDto> GetByIdAsync(string id);
        Task<FacilityDto> GetByCodeAsync(string code);
        Task<FacilityDto> CreateAsync(FacilityDto facilityDto);
        Task<FacilityDto> UpdateAsync(string id, FacilityDto facilityDto);
        Task<bool> DeleteAsync(string id);
        Task<PagedDto<FacilityDto>> GetAllAsync(FacilityQueryParameters queryParameters);
    }
}