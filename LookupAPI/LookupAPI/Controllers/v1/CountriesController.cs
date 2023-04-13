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
    public class CountriesController : ControllerBase
    {
        private readonly ILookupEngine _lookupEngine;
        private readonly IMapper _mapper;

        public CountriesController(ILookupEngine lookupEngine, IMapper mapper) {
            _lookupEngine = lookupEngine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var countries = await _lookupEngine.GetCountriesAsync();
            return Ok(_mapper.Map<IEnumerable<Country>>(countries));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
