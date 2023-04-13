using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPersonAPI.Contracts.Dtos;
using SalesPersonAPI.Engines.Interfaces;

namespace SalesPersonAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    [ApiController]
    public class SalesPersonsController : ControllerBase
    {
        private readonly ISalesPersonEngine _salesPersonEngine;
        private readonly IMapper _mapper;

        public SalesPersonsController(ISalesPersonEngine salesPersonEngine, IMapper mapper)
        {
            _salesPersonEngine = salesPersonEngine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var salesPersons = await _salesPersonEngine.GetSalesPersonsAsync();
            return Ok(_mapper.Map<IEnumerable<SalesPerson>>(salesPersons));
        }

        [HttpGet("{salesPersonId}")]
        public async Task<ActionResult> GetSalesPersonById(int salesPersonId)
        {
            var salesPerson = await _salesPersonEngine.GetSalesPersonByIdAsync(salesPersonId);
            return Ok(_mapper.Map<SalesPerson>(salesPerson));
        }

        [HttpGet("state/{stateId}")]
        public async Task<ActionResult> GetSalesPersonsByStateId(int stateId)
        {
            var salesPersons = await _salesPersonEngine.GetSalesPersonsByStateIdAsync(stateId);
            return Ok(_mapper.Map<IEnumerable<SalesPerson>>(salesPersons));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalesPerson salesPerson)
        {
            try
            {
                salesPerson.CreateByUserId = int.Parse(User.Identity.Name);
                var salesPersonModel = _mapper.Map<Domain.Models.SalesPerson>(salesPerson);
                int salesPersonId = await _salesPersonEngine.CreateSalesPersonAsync(salesPersonModel);
                return Created("", salesPersonId);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
