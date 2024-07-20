using Hulk.Core.Dtos.EntityDtos;

namespace Hulk.Core.Dtos.BrokerDtos
{
    public class BrokerUpdateDto : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal CurrentAmount { get; set; }
    }
}
