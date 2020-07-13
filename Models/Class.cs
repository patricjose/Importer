using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class Class
    {
        [JsonPropertyName("p")]
        public P p { get; set; }

        [JsonPropertyName("c")]
        public C c { get; set; }
    }
}