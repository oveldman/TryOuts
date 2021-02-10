using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Info;
using CoinChecker.Base.Interfaces;

namespace CoinChecker.Cex.Info
{
    public class CexCoinManager : BaseCoinManager, ICoinManager
    {
        public CexCoinManager()
        {
        }

        public override string GetCoinName(CoinType coinType)
        {
            return base.GetCoinName(coinType);
        }
    }
}
