using System;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;

namespace CoinChecker.Bittrex.Info
{
    public class BittrexUrls : IUrlsHandler
    {
        private readonly ExchangeType Type = ExchangeType.Bittrex;

        private readonly ICoinManager CoinManager;

        private readonly string BaseUrl = "https://api.bittrex.com";
        private readonly string Version = "v3";

        private readonly string UrlGetValue = "markets/{0}-{1}/ticker";

        public BittrexUrls(Func<ExchangeType, ICoinManager> coinManagerResolver)
        {
            CoinManager = coinManagerResolver(Type);
        }

        public string GetValueUrl(CoinType baseCoin, CoinType prizeCoin)
        {
            string baseCoinName = CoinManager.GetCoinName(baseCoin);
            string prizeCoinName = CoinManager.GetCoinName(prizeCoin);

            return GetBaseUrl() + string.Format(UrlGetValue, baseCoinName, prizeCoinName);
        }

        private string GetBaseUrl()
        {
            return $"{BaseUrl}/{Version}/";
        }
    }
}
