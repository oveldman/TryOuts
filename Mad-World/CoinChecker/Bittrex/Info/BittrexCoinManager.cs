using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Info;
using CoinChecker.Base.Interfaces;

namespace CoinChecker.Bittrex.Info
{
    public class BittrexCoinManager : BaseCoinManager, ICoinManager
    {
        public override string GetCoinName(CoinType coinType)
        {
            return base.GetCoinName(coinType);
        }
    }
}
