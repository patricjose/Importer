using System;
using System.Collections.Generic;

namespace SmartStocksImporter.Models
{
    public class ImportWallet
    {
        public Guid Id { get; set; }
        public string Fund { get; set; }
        public List<Asset> Assets { get; set; }
        public decimal Total { get; set; }
    }
}