using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Coins.Interfaces;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;
using CoinChecker.Base.Models;

namespace BusinessLayer.Coins
{
    public class ExchangeManager : IExchangeManager
    {
        private readonly IEnumerable<IExchangeAPI> ExchangeAPIs;

        public ExchangeManager(IEnumerable<IExchangeAPI> exchangeAPIs)
        {
            ExchangeAPIs = exchangeAPIs;
        }

        public List<Coin> GetAllValues(CoinType baseCoin, CoinType prizeCoin)
        {
            return ExchangeAPIs.Select(ea => ea.GetValue(baseCoin, prizeCoin)).ToList();
        }
    }
}
