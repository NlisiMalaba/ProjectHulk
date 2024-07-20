using Hulk.Core.Dtos.EntityDtos;

namespace Hulk.Core.Dtos.BrokerDtos
{
    public class BrokerResponseDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal ProfitOrLoss { get => InitialAmount - CurrentAmount; }  
    }
}
