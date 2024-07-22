using Hulk.Core.Dtos;
using Hulk.Core.Dtos.PairDtos;
using Hulk.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hulk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairController : ControllerBase
    {
        private readonly IPairService _pairService;

        public PairController(IPairService pairService)
        {
            _pairService = pairService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PairResponseDto>>>> GetAllPairs()
        {
            return Ok(await _pairService.GetAllPairs());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PairResponseDto>>> Get(int id)
        {
            return Ok(await _pairService.GetPair(id));
        }

        [HttpGet("minimal")]
        public async Task<ActionResult<ServiceResponse<PairMinimalResponseDto>>> GetPairsMinimal()
        {
            return Ok(await _pairService.GetAllPairsMinimal());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PairResponseDto>>>> CreatePair(PairCreateRequestDto request)
        {
            return Ok(await _pairService.CreatePair(request));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PairResponseDto>>>> UpdatePair(PairUpdateDto request)
        {
            return Ok(await _pairService.UpdatePair(request));
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<PairResponseDto>>>> DeletePair(int id)
        {
            return Ok(await _pairService.DeletePair(id));
        }
    }
}
