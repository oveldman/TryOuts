using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Models;

namespace CoinChecker.Base.Info
{
    public class BaseCoinManager
    {
        public BaseCoinManager()
        {
        }

        public virtual string GetCoinName(CoinType coinType)
        {
            return coinType switch
            {
                CoinType.Euro => "EUR",
                CoinType.Dollar => "USD",
                CoinType.Bitcoin => "BTC",
                CoinType.Cardano => "ADA",
                _ => string.Empty,
            };
        }
    }
}
