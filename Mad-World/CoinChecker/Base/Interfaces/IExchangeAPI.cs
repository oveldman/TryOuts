using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Models;

namespace CoinChecker.Base.Interfaces
{
    public interface IExchangeAPI
    {
        Coin GetValue(CoinType baseCoin, CoinType prizeCoin);
    }
}
