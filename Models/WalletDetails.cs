using System;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class WalletDetails
    {
        [JsonPropertyName("date")]
        public DateTime date { get; set; }

        [JsonPropertyName("wallet")]
        public Wallet wallet { get; set; }
    }
}