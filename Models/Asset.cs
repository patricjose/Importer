using System;

namespace SmartStocksImporter.Models
{
    public class Asset 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public Guid WalletId {get; set; }
    }
}