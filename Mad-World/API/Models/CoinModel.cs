using System;
using CoinChecker.Base.Models;

namespace API.Models
{
    public class CoinModel
    {
        public string ExchangeName { get; set; }
        public string Name { get; set; }
        public string TradeCoinName { get; set; }
        public double LastTradeValue { get; set; }
        public double BidValue { get; set; }
        public double AskValue { get; set; }

        public CoinModel(Coin coin)
        {
            ExchangeName = coin.ExchangeName.ToString();
            Name = coin.Name.ToString();
            TradeCoinName = coin.TradeCoinName.ToString();
            LastTradeValue = coin.LastTradeValue;
            BidValue = coin.BidValue;
            AskValue = coin.AskValue;
        }

        public CoinModel()
        {

        }
    }
}
