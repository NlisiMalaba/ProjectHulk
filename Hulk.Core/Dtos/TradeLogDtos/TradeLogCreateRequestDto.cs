using Hulk.Data.Entities;
using Hulk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk.Core.Dtos.TradeLogDtos
{
    public class TradeLogCreateRequestDto
    {
        public int PairId { get; set; }
        public string PairName { get; set; }
        public int BrokerId { get; set; }
        public string BrokerName { get; set; }
        public decimal LotSize { get; set; }
        public string Position { get; set; }
        public string TradeTypeName { get; set; }
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
