using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;
using CoinChecker.Base.Models;
using CoinChecker.Cex.ApiModels;
using Common.Interfaces;

namespace CoinChecker.Cex
{
    public class CexExchange : IExchangeAPI
    {
        private readonly ExchangeType Type = ExchangeType.Cex;

        private readonly IUrlsHandler UrlsHandler;
        private readonly IService Service;

        public CexExchange(Func<ExchangeType, IUrlsHandler> urlHandlerResolver, IService service)
        {
            UrlsHandler = urlHandlerResolver(Type);
            Service = service;
        }

        public Coin GetValue(CoinType baseCoin, CoinType prizeCoin)
        {
            string getValueUrl = UrlsHandler.GetValueUrl(baseCoin, prizeCoin);
            string cexResponse = Service.SendGetRequest(getValueUrl);
            TickerResponse tickerResponse = JsonSerializer.Deserialize<TickerResponse>(cexResponse);
            return new Coin
            {
                ExchangeName = Type,
                Name = baseCoin,
                TradeCoinName = prizeCoin,
                LastTradeValue = double.Parse(tickerResponse.Last),
                AskValue = tickerResponse.Ask,
                BidValue = tickerResponse.Bid
            };
        }
    }
}
