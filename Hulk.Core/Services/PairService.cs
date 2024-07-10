using AutoMapper;
using Hulk.Core.Dtos;
using Hulk.Core.Dtos.PairDtos;
using Hulk.Core.Helpers;
using Hulk.Core.Interfaces;
using Hulk.Data.DbContexts;
using Hulk.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hulk.Core.Services
{
    public class PairService : IPairService
    {
        private readonly HulkDbContext _context;
        private readonly IMapper _mapper;

        public PairService(HulkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task<ServiceResponse<List<PairResponseDto>>> CreatePairServiceResponse(string message)
        {
            try
            {
                var pairs = await _context.Pairs.Where(x => !x.IsDeleted).ToListAsync();

                var result = _mapper.Map<List<PairResponseDto>>(pairs);

                var response = new ServiceResponse<List<PairResponseDto>>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = message,
                    Data = result,
                };

                return response;
            } 
            catch(Exception ex)
            {
                throw new AppException("An error occured ", ex.Message);
            }
        }

        public async Task<ServiceResponse<List<PairResponseDto>>> CreatePair(PairCreateRequestDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var pair = _mapper.Map<Pair>(request);
                await _context.Pairs.AddAsync(pair);
                await _context.SaveChangesAsync();

                var response = await CreatePairServiceResponse("Pair created successfully");

                await transaction.CommitAsync();

                return response;
            }
            catch(Exception ex)
            {
               await transaction.RollbackAsync();

                throw new AppException("An error occured while creating a pair", ex);
            }
        }

        public async Task<ServiceResponse<List<PairResponseDto>>> DeletePair(int Id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var pair = await _context.Pairs.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted) ?? throw new AppException($"Pair {Id} count not be found");

                pair.IsDeleted = true;
                _context.Pairs.Update(pair);
                await _context.SaveChangesAsync();

                var response = await CreatePairServiceResponse("Pair deleted successfully");

                await transaction.CommitAsync();

                return response;
            } 
            catch(Exception ex)
            {
                await transaction.RollbackAsync();

                throw new AppException("An error occured while deleting pair", ex);
            }
        }

        public async Task<ServiceResponse<List<PairResponseDto>>> GetAllPairs()
        {
           return await CreatePairServiceResponse("Pairs retrieved successfully");
        }

        public async Task<ServiceResponse<List<PairMinimalResponseDto>>> GetAllPairsMinimal()
        {
            try
            {
                var pairs = await _context.Pairs.Where(x => !x.IsDeleted).ToListAsync();

                var response = new ServiceResponse<List<PairMinimalResponseDto>>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = "Pairs retrieved successfully",
                    Data = _mapper.Map<List<PairMinimalResponseDto>>(pairs)
                };

                return response;
            } 
            catch (Exception ex)
            {
                throw new AppException("An error occured while retriving pairs", ex);
            }
        }

        public async Task<ServiceResponse<PairResponseDto>> GetPair(int Id)
        {
            try
            {
                var pair = await _context.Pairs
                    .FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted) ?? throw new AppException($"Pair {Id} could not be found");

                var res = _mapper.Map<PairResponseDto>(pair);
                var response = new ServiceResponse<PairResponseDto>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = "Pair retrieved successfully",
                    Data = res
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occured", ex);
            }
        }

        public async Task<ServiceResponse<List<PairResponseDto>>> UpdatePair(PairUpdateDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var pair = await _context.Pairs.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted) ?? throw new AppException($"Pair {request.Id} could not be found");

                pair = _mapper.Map(request, pair);
                _context.Pairs.Update(pair);
                await _context.SaveChangesAsync();

                var response = await CreatePairServiceResponse("Pair updated successfully");

                await transaction.CommitAsync();

                return response;
            } 
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new AppException("An error occured while updating pair", ex);
            }
        }
    }
}
