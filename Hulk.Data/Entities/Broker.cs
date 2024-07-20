using Hulk.Data.AggregateRoots;

namespace Hulk.Data.Entities
{
    public class Broker : FullAuditedAggregatedRoot<int>
    {
        public string Name { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal CurrentAmount { get; set; }
    }
}
