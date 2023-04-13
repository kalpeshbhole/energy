using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Contracts.Dtos;
using StoreAPI.Engines.Interfaces;

namespace StoreAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreEngine _storeEngine;
        private readonly IMapper _mapper;

        public StoresController(IStoreEngine storeEngine, IMapper mapper)
        {
            _storeEngine = storeEngine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var stores = await _storeEngine.GetStoresAsync();
            return Ok(_mapper.Map<IEnumerable<Store>>(stores));
        }

        [HttpGet("state/{stateId}")]
        public async Task<ActionResult> Get(int stateId)
        {
            var stores = await _storeEngine.GetStoresByStateIdAsync(stateId);
            return Ok(_mapper.Map<IEnumerable<Store>>(stores));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Store store)
        {
            try
            {
                store.CreateByUserId = int.Parse(User.Identity.Name);
                var storeModel = _mapper.Map<Domain.Models.Store>(store);
                int storeId = await _storeEngine.CreateStoreAsync(storeModel);
                return Created("", storeId);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
