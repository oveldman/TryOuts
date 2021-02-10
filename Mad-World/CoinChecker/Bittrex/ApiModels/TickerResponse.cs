using System;
using System.Text.Json.Serialization;

namespace CoinChecker.Bittrex.ApiModels
{
    public class TickerResponse
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("lastTradeRate")]
        public string LastTradeRate { get; set; }
        [JsonPropertyName("bidRate")]
        public string BidRate { get; set; }
        [JsonPropertyName("askRate")]
        public string AskRate { get; set; }
    }
}
