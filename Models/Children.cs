using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class Children
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("children")]
        public List<Children> children { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }
    }
}