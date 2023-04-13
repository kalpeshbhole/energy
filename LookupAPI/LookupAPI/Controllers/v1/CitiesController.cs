using AutoMapper;
using LookupAPI.Contracts.Dtos;
using LookupAPI.Engines.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LookupAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ILookupEngine _lookupEngine;
        private readonly IMapper _mapper;

        public CitiesController(ILookupEngine lookupEngine, IMapper mapper)
        {
            _lookupEngine = lookupEngine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var cities = await _lookupEngine.GetCitiesAsync();
            return Ok(_mapper.Map<IEnumerable<City>>(cities));
        }

        [HttpGet("stateId/{stateId}")]
        public async Task<ActionResult> Get(int stateId)
        {
            var cities = await _lookupEngine.GetCitiesByStateIdAsync(stateId);
            return Ok(_mapper.Map<IEnumerable<City>>(cities));
        }
    }
}
