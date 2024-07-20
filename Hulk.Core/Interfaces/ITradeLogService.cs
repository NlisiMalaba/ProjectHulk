
using Hulk.Core.Dtos;
using Hulk.Core.Dtos.TradeLogDtos;

namespace Hulk.Core.Interfaces
{
    public interface ITradeLogService
    {
        Task<ServiceResponse<List<TradeLogResponseDto>>> CreateTradeLog(TradeLogCreateRequestDto request);

        Task<ServiceResponse<List<TradeLogResponseDto>>> GetAllTradeLogs();

        Task<ServiceResponse<TradeLogResponseDto>> GetTradeLog(int Id);

        Task<ServiceResponse<List<TradeLogResponseDto>>> UpdateTradeLog(TradeLogUpdateDto request);

        Task<ServiceResponse<List<TradeLogResponseDto>>> DeleteTradeLog(int Id);
    }
}
