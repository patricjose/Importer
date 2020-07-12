using System;

namespace Importer.Models
{
    public class Asset 
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public decimal size { get; set; }
        public Guid walletId {get; set; }
    }
}