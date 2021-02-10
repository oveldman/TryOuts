using System;
using System.Text.Json;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;
using CoinChecker.Base.Models;
using CoinChecker.Bittrex.ApiModels;
using Common.Interfaces;

namespace CoinChecker.Bittrex
{
    public class BittrexExchange : IExchangeAPI
    {
        private readonly ExchangeType Type = ExchangeType.Bittrex;

        private readonly IUrlsHandler UrlsHandler;
        private readonly IService Service;

        public BittrexExchange(Func<ExchangeType, IUrlsHandler> urlHandlerResolver, IService service)
        {
            UrlsHandler = urlHandlerResolver(Type);
            Service = service;
        }

        public Coin GetValue(CoinType baseCoin, CoinType prizeCoin)
        {
            string getValueUrl = UrlsHandler.GetValueUrl(baseCoin, prizeCoin);
            string bittrexResponse = Service.SendGetRequest(getValueUrl);
            TickerResponse tickerResponse = JsonSerializer.Deserialize<TickerResponse>(bittrexResponse);
            return new Coin
            {
                ExchangeName = Type,
                Name = baseCoin,
                TradeCoinName = prizeCoin,
                LastTradeValue = double.Parse(tickerResponse.LastTradeRate),
                AskValue = double.Parse(tickerResponse.AskRate),
                BidValue = double.Parse(tickerResponse.BidRate)
            };
        }
    }
}
