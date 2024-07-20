using AutoMapper;
using Hulk.Core.Dtos;
using Hulk.Core.Dtos.PairDtos;
using Hulk.Core.Dtos.TradeLogDtos;
using Hulk.Core.Helpers;
using Hulk.Core.Interfaces;
using Hulk.Data.DbContexts;
using Hulk.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hulk.Core.Services
{
    public class TradeLogService : ITradeLogService
    {
        private readonly HulkDbContext _context;
        private readonly IMapper _mapper;

        public TradeLogService(HulkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task<ServiceResponse<List<TradeLogResponseDto>>> CreateTradeLogServiceResponse(string message)
        {
            try
            {
                var tradeLogs = await _context.TradeLogs.Where(x => !x.IsDeleted).ToListAsync();

                var result = _mapper.Map<List<TradeLogResponseDto>>(tradeLogs);

                var response = new ServiceResponse<List<TradeLogResponseDto>>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = message,
                    Data = result,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occured ", ex.Message);
            }
        }

        public async Task<ServiceResponse<List<TradeLogResponseDto>>> CreateTradeLog(TradeLogCreateRequestDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var tradeLog = _mapper.Map<TradeLog>(request);
                await _context.TradeLogs.AddAsync(tradeLog);
                await _context.SaveChangesAsync();

                var response = await CreateTradeLogServiceResponse("Trade Log created successfully");

                await transaction.CommitAsync();

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new AppException("An error occured while creating a trade log", ex);
            }
        }

        public async Task<ServiceResponse<List<TradeLogResponseDto>>> DeleteTradeLog(int Id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var tradeLog = await _context.TradeLogs.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted) ?? throw new AppException($"Trade log {Id} could not be found");

                tradeLog.IsDeleted = true;
                _context.TradeLogs.Update(tradeLog);
                await _context.SaveChangesAsync();

                var response = await CreateTradeLogServiceResponse("Trade log deleted successfully");

                await transaction.CommitAsync();

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new AppException("An error occured while deleting trade log", ex);
            }
        }

        public async Task<ServiceResponse<List<TradeLogResponseDto>>> GetAllTradeLogs()
        {
            return await CreateTradeLogServiceResponse("Trade logs retrieved successfully");
        }

        public async Task<ServiceResponse<TradeLogResponseDto>> GetTradeLog(int Id)
        {
            try
            {
                var tradeLog = await _context.TradeLogs
                    .FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted) ?? throw new AppException($"Pair {Id} could not be found");

                var res = _mapper.Map<TradeLogResponseDto>(tradeLog);
                var response = new ServiceResponse<TradeLogResponseDto>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = "Trade log retrieved successfully",
                    Data = res
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occured", ex);
            }

        }

        public async Task<ServiceResponse<List<TradeLogResponseDto>>> UpdateTradeLog(TradeLogUpdateDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var tradeLog = await _context.TradeLogs.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted) ?? throw new AppException($"Trade log {request.Id} could not be found");

                tradeLog = _mapper.Map(request, tradeLog);
                _context.TradeLogs.Update(tradeLog);
                await _context.SaveChangesAsync();

                var response = await CreateTradeLogServiceResponse("Trade log updated successfully");

                await transaction.CommitAsync();

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new AppException("An error occured while updating Trade log", ex);
            }
        }
    }
}
