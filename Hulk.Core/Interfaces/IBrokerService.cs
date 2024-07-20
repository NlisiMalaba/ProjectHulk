using Hulk.Core.Dtos;
using Hulk.Core.Dtos.BrokerDtos;

namespace Hulk.Core.Interfaces
{
    public interface IBrokerService
    {
        Task<ServiceResponse<List<BrokerResponseDto>>> CreateBroker(BrokerCreateRequestDto request);

        Task<ServiceResponse<List<BrokerResponseDto>>> GetAllBrokers();

        Task<ServiceResponse<BrokerResponseDto>> GetBroker(int Id);

        Task<ServiceResponse<List<BrokerResponseDto>>> UpdateBroker(BrokerUpdateDto request);

        Task<ServiceResponse<List<BrokerResponseDto>>> DeleteBroker(int Id);

        Task<ServiceResponse<List<BrokerMinimalResponseDto>>> GetAllBrokersMinimal();
    }
}
