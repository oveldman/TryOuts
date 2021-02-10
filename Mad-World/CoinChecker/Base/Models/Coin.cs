using System;
using CoinChecker.Base.Enums;

namespace CoinChecker.Base.Models
{
    public class Coin
    {
        public ExchangeType ExchangeName { get; set; }
        public CoinType Name { get; set; }
        public CoinType TradeCoinName { get; set;}
        public double LastTradeValue { get; set; }
        public double BidValue { get; set; }
        public double AskValue { get; set; }
    }
}
