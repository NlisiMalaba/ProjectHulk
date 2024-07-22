using Hulk.Core.Dtos;
using Hulk.Core.Dtos.TradeLogDtos;
using Hulk.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hulk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeLogController : ControllerBase
    {
        private readonly ITradeLogService _tradeLogService;

        public TradeLogController(ITradeLogService tradeLogService)
        {
            _tradeLogService = tradeLogService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TradeLogResponseDto>>>> GetAllTradeLogs()
        {
            return Ok(await _tradeLogService.GetAllTradeLogs());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TradeLogResponseDto>>> GetTradeLog(int id)
        {
            return Ok(await _tradeLogService.GetTradeLog(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TradeLogResponseDto>>>> CreateTradeLog(TradeLogCreateRequestDto request)
        {
            return Ok(await _tradeLogService.CreateTradeLog(request));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TradeLogResponseDto>>>> UpdateTradeLog(TradeLogUpdateDto request)
        {
            return Ok(await _tradeLogService.UpdateTradeLog(request));
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<TradeLogResponseDto>>>> DeleteTradeLog(int id)
        {
            return Ok(await _tradeLogService.DeleteTradeLog(id));
        }

    }
}
