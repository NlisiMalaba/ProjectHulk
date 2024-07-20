namespace Hulk.Core.Dtos.BrokerDtos
{
    public class BrokerCreateRequestDto
    {
        public string Name { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal CurrentAmount { get; set; }
    }
}
