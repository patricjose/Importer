using System;
using System.Collections.Generic;

namespace SmartStocksImporter.Models
{
    public class ImportWallet
    {
        public Guid Id { get; set; }
        public string FundName { get; set; }
        public List<ImportAsset> Assets { get; set; }
        public decimal Total { get; set; }
    }
}