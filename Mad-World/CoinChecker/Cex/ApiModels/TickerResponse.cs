using System;
using System.Text.Json.Serialization;

namespace CoinChecker.Cex.ApiModels
{
    public class TickerResponse
    {
        [JsonPropertyName("pair")]
        public string Pair { get; set; }
        [JsonPropertyName("last")]
        public string Last { get; set; }
        [JsonPropertyName("bid")]
        public double Bid { get; set; }
        [JsonPropertyName("ask")]
        public double Ask { get; set; }
    }
}
