using markamed_api.Interfaces.IService;
using markamed_api.Models.Dto;
using markamed_api.Models.Entities;
using markamed_api.Data;
using markamed_api.QueryParameters;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace markamed_api.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public FacilityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FacilityDto> GetByIdAsync(string id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                throw new KeyNotFoundException($"Facility with ID {id} not found.");
            }
            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task<FacilityDto> GetByCodeAsync(string code)
        {
            var facility = await _context.Facilities.FirstOrDefaultAsync(f => f.Code == code);
            if (facility == null)
            {
                throw new KeyNotFoundException($"Facility with code {code} not found.");
            }

            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task<PagedDto<FacilityDto>> GetAllAsync(FacilityQueryParameters queryParameters)
        {
            var facilities = _context.Facilities.AsNoTracking();

            if (!string.IsNullOrEmpty(queryParameters.Code))
            {
                facilities = facilities.Where(f => f.Code.Contains(queryParameters.Code));
            }
            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                facilities = facilities.Where(f => f.Name.Contains(queryParameters.Name));
            }
            if (!string.IsNullOrEmpty(queryParameters.FacilityMajorType))
            {
                facilities = facilities.Where(f => f.FacilityMajorType == queryParameters.FacilityMajorType);
            }
            if (!string.IsNullOrEmpty(queryParameters.FacilityType))
            {
                facilities = facilities.Where(f => f.FacilityType == queryParameters.FacilityType);
            }
            if (!string.IsNullOrEmpty(queryParameters.Region))
            {
                facilities = facilities.Where(f => f.Region == queryParameters.Region);
            }
            if (!string.IsNullOrEmpty(queryParameters.Province))
            {
                facilities = facilities.Where(f => f.Province == queryParameters.Province);
            }
            if (!string.IsNullOrEmpty(queryParameters.City))
            {
                facilities = facilities.Where(f => f.City == queryParameters.City);
            }
            if (!string.IsNullOrEmpty(queryParameters.Barangay))
            {
                facilities = facilities.Where(f => f.Barangay == queryParameters.Barangay);
            }
            if (queryParameters.MinBedCapacity.HasValue)
            {
                facilities = facilities.Where(f => f.BedCapacity >= queryParameters.MinBedCapacity.Value);
            }
            if (queryParameters.MaxBedCapacity.HasValue)
            {
                facilities = facilities.Where(f => f.BedCapacity <= queryParameters.MaxBedCapacity.Value);
            }
            if (!string.IsNullOrEmpty(queryParameters.LicenseStatus))
            {
                facilities = facilities.Where(f => f.LicenseStatus == queryParameters.LicenseStatus);
            }
            if (queryParameters.HasLicense.HasValue)
            {
                if (queryParameters.HasLicense.Value)
                {
                    facilities = facilities.Where(f => !string.IsNullOrEmpty(f.LicenseNumber));
                }
                else
                {
                    facilities = facilities.Where(f => string.IsNullOrEmpty(f.LicenseNumber));
                }
            }

            var totalCount = await facilities.CountAsync();
            var pagedFacilities = await facilities
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToListAsync();
            
            var facilityDtos = _mapper.Map<List<FacilityDto>>(pagedFacilities);
        
            return new PagedDto<FacilityDto>
            {
                Items = facilityDtos,
                TotalCount = totalCount,
                PageNumber = queryParameters.PageNumber,
                PageSize = queryParameters.PageSize
            };
        }

        public async Task<FacilityDto> CreateAsync(FacilityDto facilityDto)
        {
            if (await _context.Facilities.AnyAsync(f => f.Code == facilityDto.Code))
            {
                throw new InvalidOperationException($"Facility with code {facilityDto.Code} already exists.");
            }

            var facility = _mapper.Map<Facility>(facilityDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task<FacilityDto> UpdateAsync(string id, FacilityDto facilityDto)
        {
            var existingFacility = await _context.Facilities.FindAsync(id);
            if (existingFacility == null)
            {
                throw new KeyNotFoundException($"Facility with ID {id} not found.");
            }

            _mapper.Map(facilityDto, existingFacility);
            await _context.SaveChangesAsync();
            return _mapper.Map<FacilityDto>(existingFacility);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existingFacility = await _context.Facilities.FindAsync(id);
            if (existingFacility == null)
            {
                throw new KeyNotFoundException($"Facility with ID {id} not found.");
            }

            _context.Facilities.Remove(existingFacility);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}