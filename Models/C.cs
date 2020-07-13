using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class C
    {
        [JsonPropertyName("n")]
        public string n { get; set; }

        [JsonPropertyName("s")]
        public string s { get; set; }
    }
}