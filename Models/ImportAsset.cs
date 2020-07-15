using System;

namespace SmartStocksImporter.Models
{
    public class ImportAsset 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string FundName { get; set; }
        public Guid WalletId { get; set; }
    }
}