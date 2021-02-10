using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;

namespace CoinChecker.Cex.Info
{
    public class CexUrls : IUrlsHandler
    {
        private readonly ExchangeType Type = ExchangeType.Cex;

        private readonly ICoinManager CoinManager;

        private readonly string BaseUrl = "https://cex.io/api/";

        private readonly string UrlGetValue = "ticker/{0}/{1}";

        public CexUrls(Func<ExchangeType, ICoinManager> coinManagerResolver)
        {
            CoinManager = coinManagerResolver(Type);
        }

        public string GetValueUrl(CoinType baseCoin, CoinType prizeCoin)
        {
            string baseCoinName = CoinManager.GetCoinName(baseCoin);
            string prizeCoinName = CoinManager.GetCoinName(prizeCoin);

            return BaseUrl + string.Format(UrlGetValue, baseCoinName, prizeCoinName);
        }

    }
}
