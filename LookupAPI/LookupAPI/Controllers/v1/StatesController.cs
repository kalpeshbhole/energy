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
    public class StatesController : ControllerBase
    {
        private readonly ILookupEngine _lookupEngine;
        private readonly IMapper _mapper;
        public StatesController(ILookupEngine lookupEngine, IMapper mapper)
        {
            _lookupEngine = lookupEngine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var states = await _lookupEngine.GetStatesAsync();
            return Ok(_mapper.Map<IEnumerable<State>>(states));
        }

        [HttpGet("countryId/{countryId}")]
        public async Task<ActionResult> Get(int countryId)
        {
            var states = await _lookupEngine.GetStatesByCountryIdAsync(countryId);
            return Ok(_mapper.Map<IEnumerable<State>>(states));
        }
    }
}
