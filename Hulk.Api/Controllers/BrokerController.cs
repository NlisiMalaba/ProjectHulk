using Hulk.Core.Dtos;
using Hulk.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hulk.Core.Dtos.BrokerDtos;

namespace Hulk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly IBrokerService _brokerService;

        public BrokerController(IBrokerService brokerService)
        {
            _brokerService = brokerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BrokerResponseDto>>>> GetAllBrokers()
        {
            return Ok(await _brokerService.GetAllBrokers());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BrokerResponseDto>>> Get(int id)
        {
            return Ok(await _brokerService.GetBroker(id));
        }

        [HttpGet("minimal")]
        public async Task<ActionResult<ServiceResponse<BrokerMinimalResponseDto>>> GetBrokersMinimal()
        {
            return Ok(await _brokerService.GetAllBrokersMinimal());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<BrokerResponseDto>>>> CreateBroker(BrokerCreateRequestDto request)
        {
            return Ok(await _brokerService.CreateBroker(request));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<BrokerResponseDto>>>> UpdateBroker(BrokerUpdateDto request)
        {
            return Ok(await _brokerService.UpdateBroker(request));
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<BrokerResponseDto>>>> DeleteBroker(int id)
        {
            return Ok(await _brokerService.DeleteBroker(id));
        }
    }
}
