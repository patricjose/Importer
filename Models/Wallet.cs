using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class Wallet
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("children")]
        public List<Children> children { get; set; }
    }
}