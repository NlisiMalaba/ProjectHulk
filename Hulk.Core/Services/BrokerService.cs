using AutoMapper;
using Hulk.Core.Dtos;
using Hulk.Core.Dtos.BrokerDtos;
using Hulk.Core.Helpers;
using Hulk.Core.Interfaces;
using Hulk.Data.DbContexts;
using Hulk.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hulk.Core.Services
{
    public class BrokerService : IBrokerService
    {
        private readonly IMapper _mapper;
        private readonly HulkDbContext _context;

        public BrokerService(IMapper mapper, HulkDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private async Task<ServiceResponse<List<BrokerResponseDto>>> CreateBrokerServiceResponse(string message)
        {
            try
            {
                var pairs = await _context.Brokers.Where(x => !x.IsDeleted).ToListAsync();

                var result = _mapper.Map<List<BrokerResponseDto>>(pairs);

                var response = new ServiceResponse<List<BrokerResponseDto>>()
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


        public async Task<ServiceResponse<List<BrokerResponseDto>>> CreateBroker(BrokerCreateRequestDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var broker = _mapper.Map<Broker>(request);
                await _context.Brokers.AddAsync(broker);
                await _context.SaveChangesAsync();

                var response = await CreateBrokerServiceResponse("Broker Created Successfully");

                await transaction.CommitAsync();

                return response;
            } 
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new AppException("An error occured while creating a broker", ex);
            }
        }

        public async Task<ServiceResponse<List<BrokerResponseDto>>> DeleteBroker(int Id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var broker = await _context.Brokers.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted) ?? throw new AppException($"Broker {Id} count not be found");

                broker.IsDeleted = true;
                _context.Brokers.Update(broker);
                await _context.SaveChangesAsync();

                var response = await CreateBrokerServiceResponse("Broker deleted successfully");

                await transaction.CommitAsync();

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new AppException("An error occured while deleting broker", ex);
            }
        }

        public async Task<ServiceResponse<List<BrokerResponseDto>>> GetAllBrokers()
        {
            return await CreateBrokerServiceResponse("Brokers retrieved successfully");
        }

        public async Task<ServiceResponse<List<BrokerMinimalResponseDto>>> GetAllBrokersMinimal()
        {
            try
            {
                var brokers = await _context.Brokers.Where(x => !x.IsDeleted).ToListAsync();

                var response = new ServiceResponse<List<BrokerMinimalResponseDto>>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = "Brokers retrieved successfully",
                    Data = _mapper.Map<List<BrokerMinimalResponseDto>>(brokers)
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occured while retriving brokers", ex);
            }
        }

        public async Task<ServiceResponse<BrokerResponseDto>> GetBroker(int Id)
        {
            try
            {
                var broker = await _context.Brokers
                    .FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted) ?? throw new AppException($"Broker {Id} could not be found");

                var res = _mapper.Map<BrokerResponseDto>(broker);
                var response = new ServiceResponse<BrokerResponseDto>()
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = "Broker retrieved successfully",
                    Data = res
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occured", ex);
            }
        }

        public async Task<ServiceResponse<List<BrokerResponseDto>>> UpdateBroker(BrokerUpdateDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var broker = await _context.Brokers.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted) ?? throw new AppException($"Broker {request.Id} could not be found");

                broker = _mapper.Map(request, broker);
                _context.Brokers.Update(broker);
                await _context.SaveChangesAsync();

                var response = await CreateBrokerServiceResponse("Broker updated successfully");

                await transaction.CommitAsync();

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new AppException("An error occured while updating broker", ex);
            }
        }
    }
}
