﻿using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;

namespace CoinChecker.Cex.Info
{
    public class CexCoinManager : ICoinManager
    {
        public CexCoinManager()
        {
        }

        public string GetCoinName(CoinType coinType)
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
