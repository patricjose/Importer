using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Importer.Models
{
    public class Wallet
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("children")]
        public List<Children> Children { get; set; }
    }
}