using System;
using CoinChecker.Base.Enums;

namespace CoinChecker.Base.Interfaces
{
    public interface ICoinManager
    {
        string GetCoinName(CoinType coinType);
    }
}
