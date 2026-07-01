using Microsoft.AspNetCore.Mvc;
using markamed_api.Models.Dto;
using markamed_api.Interfaces.IService;
using markamed_api.QueryParameters;

namespace markamed_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService facilityService;
        public FacilityController(IFacilityService facilityService)
        {
            this.facilityService = facilityService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FacilityDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFacilityById(string id)
        {
            var facility = await facilityService.GetByIdAsync(id);
            return Ok(facility);
        }

        [HttpGet("code/{code}")]
        [ProducesResponseType(typeof(FacilityDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFacilityByCode(string code)
        {
            var facility = await facilityService.GetByCodeAsync(code);
            return Ok(facility);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FacilityDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListFacilities([FromQuery] FacilityQueryParameters parameters)
        {
            var facilities = await facilityService.GetAllAsync(parameters);
            return Ok(facilities);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FacilityDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateFacility([FromBody] FacilityDto facilityDto)
        {
            var facility = await facilityService.CreateAsync(facilityDto);
            return CreatedAtAction(nameof(GetFacilityById), new { id = facility.Id }, facility);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FacilityDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateFacility(string id, [FromBody] FacilityDto facilityDto)
        {
            var updatedFacility = await facilityService.UpdateAsync(id, facilityDto);
            return Ok(updatedFacility);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFacility(string id)
        {
            await facilityService.DeleteAsync(id);
            return Ok();
        }
    }
}