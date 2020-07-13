using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class Children
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("children")]
        public List<Children> children { get; set; }

        [JsonPropertyName("size")]
        public decimal size { get; set; }

        [JsonPropertyName("slug")]
        public string slug { get; set; }

        [JsonPropertyName("sum")]
        public decimal sum { get; set; }
    }
}