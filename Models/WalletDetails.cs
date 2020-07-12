using System;
using System.Text.Json.Serialization;

namespace Importer.Models
{
    public class WalletDetails
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("wallet")]
        public Wallet Wallet { get; set; }
    }
}