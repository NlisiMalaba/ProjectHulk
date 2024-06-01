using Hulk.Data.AggregateRoots;

namespace Hulk.Data.Entities
{
    public class Pair : FullAuditedAggregatedRoot<int>
    {
        public string Name { get; set; }
        public int? NumberOfTrades { get; set; }
    }
}
