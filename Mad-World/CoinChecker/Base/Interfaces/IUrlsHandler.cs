using System;
using CoinChecker.Base.Enums;

namespace CoinChecker.Base.Interfaces
{
    public interface IUrlsHandler
    {
        string GetValueUrl(CoinType baseCoin, CoinType prizeCoin);
    }
}
