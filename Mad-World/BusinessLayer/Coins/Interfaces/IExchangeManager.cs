using System;
using System.Collections.Generic;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Models;

namespace BusinessLayer.Coins.Interfaces
{
    public interface IExchangeManager
    {
        List<Coin> GetAllValues(CoinType baseCoin, CoinType prizeCoin);
    }
}
