using Hulk.Core.Dtos.PairDtos;
using Hulk.Core.Dtos;

namespace Hulk.Core.Interfaces
{
    public interface IPairService
    {
        Task<ServiceResponse<List<PairResponseDto>>> CreatePair(PairCreateRequestDto request);

        Task<ServiceResponse<List<PairResponseDto>>> GetAllPairs();

        Task<ServiceResponse<PairResponseDto>> GetPair(int Id);

        Task<ServiceResponse<List<PairResponseDto>>> UpdatePair(PairUpdateDto request);

        Task<ServiceResponse<List<PairResponseDto>>> DeletePair(int Id);

        Task<ServiceResponse<List<PairMinimalResponseDto>>> GetAllPairsMinimal();
    }
}
