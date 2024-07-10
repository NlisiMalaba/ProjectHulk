using Hulk.Core.Dtos.EntityDtos;

namespace Hulk.Core.Dtos.PairDtos
{
    public class PairResponseDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }
        public int? NumberOfTrades { get; set; }
    }
}
