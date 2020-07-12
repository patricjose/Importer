using System;
using System.Collections.Generic;

namespace SmartStocksImporter.Models
{
    public class ImportWallet
    {
        public Guid id { get; set; }
        public string fund { get; set; }
        public List<Asset> assets { get; set; }
        public decimal total { get; set; }
    }
}