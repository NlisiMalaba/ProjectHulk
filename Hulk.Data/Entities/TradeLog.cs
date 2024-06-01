using Hulk.Data.AggregateRoots;

namespace Hulk.Data.Entities
{
    public class TradeLog : FullAuditedAggregatedRoot<int>
    {
        public int PairId { get; set; }
        public Pair? PairName { get; set; }
        public decimal LotSize { get; set; }
        public string Position { get; set; } // Long or Short
        public DateTime DateOfExecution { get; set; }
        public DateTime DateOfExit { get; set; } 
        public string RewardToRisk { get; set; }
        public decimal StopLossPips { get; set; }
        public decimal TakeProfitPips { get; set; }
        public decimal Profit { get; set; }
        public bool IsSuccessful { get; set; }

    }
}
