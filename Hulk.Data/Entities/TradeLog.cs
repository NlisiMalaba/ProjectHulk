using Hulk.Data.AggregateRoots;
using Hulk.Data.Enums;

namespace Hulk.Data.Entities
{
    public class TradeLog : FullAuditedAggregatedRoot<int>
    {
        public int PairId { get; set; }
        public Pair PairName { get; set; }
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }
        public decimal LotSize { get; set; }
        public Position Position { get; set; } 
        public TradeType TradeType { get; set; }
        public DateTime DateOfExecution { get; set; }
        public DateTime DateOfExit { get; set; } 
        public string RewardToRisk { get; set; }
        public decimal StopLossPips { get; set; }
        public decimal TakeProfitPips { get; set; }
        public decimal Profit { get; set; }
        public bool IsSuccessful { get; set; }
        public string Notes { get; set; }

    }
}
