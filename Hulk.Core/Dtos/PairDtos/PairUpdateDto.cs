using Hulk.Core.Dtos.EntityDtos;

namespace Hulk.Core.Dtos.PairDtos
{
    public class PairUpdateDto : EntityDto<int>
    {
        public string Name { get; set; }
        public int? NumberOfTrades { get; set; }
    }
}
