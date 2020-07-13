using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStocksImporter.Models
{
    public class Fund
    {
        [JsonPropertyName("c")]
        public long c { get; set; }

        [JsonPropertyName("n")]
        public string n { get; set; }
        
        [JsonPropertyName("s")]
        public string s { get; set; }

        [JsonPropertyName("p")]
        public decimal p { get; set; }

        [JsonPropertyName("q")]
        public int q { get; set; }

        [JsonPropertyName("cvm_class")]
        public string cvm_class { get; set; }

        [JsonPropertyName("cl_cvm")]
        public string cl_cvm { get; set; }

        [JsonPropertyName("variacao_6_meses")]
        public decimal variacao_6_meses { get; set; }

        [JsonPropertyName("v6m")]
        public decimal v6m { get; set; }

        [JsonPropertyName("fundo_cond_aberto")]
        public bool fundo_cond_aberto { get; set; }

        [JsonPropertyName("cond_ab")]
        public bool cond_ab { get; set; }

        [JsonPropertyName("fundo_exclusivo")]
        public bool fundo_exclusivo { get; set; }

        [JsonPropertyName("excl")]
        public bool excl { get; set; }

        [JsonPropertyName("restrito")]
        public bool restrito { get; set; }

        [JsonPropertyName("rest")]
        public bool rest { get; set; }

        [JsonPropertyName("fundo_invest_qualif")]
        public bool fundo_invest_qualifn { get; set; }

        [JsonPropertyName("i_qual")]
        public bool i_qual { get; set; }

        /* [JsonPropertyName("tipo_de_previdencia")]
        public bool tipo_de_previdencia { get; set; }

        [JsonPropertyName("prev")]
        public bool prev { get; set; } */

        [JsonPropertyName("fundo_tribut_lp")]
        public bool fundo_tribut_lp { get; set; }

        [JsonPropertyName("trib_lp")]
        public bool trib_lp { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("st")]
        public string st { get; set; }

        [JsonPropertyName("tipo_de_fundo")]
        public string tipo_de_fundo { get; set; }

        [JsonPropertyName("tipo")]
        public string tipo { get; set; }

        [JsonPropertyName("classe")]
        public string classe { get; set; }

        [JsonPropertyName("class")]
        public Class classs { get; set; }

        [JsonPropertyName("value")]
        public decimal value { get; set; }

        [JsonPropertyName("val")]
        public decimal val { get; set; }
        
        [JsonPropertyName("volatility")]
        public decimal volatility { get; set; }
        
        [JsonPropertyName("vol")]
        public decimal vol { get; set; }
    }
}