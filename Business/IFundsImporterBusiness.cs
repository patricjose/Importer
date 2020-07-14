using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SmartStocksImporter.Models;

namespace SmartStocksImporter.Business
{
    public interface IFundsImporterBusiness
    {
        Task<ImportWallet> GetFundWallet(string fund);
        Task<List<ImportFund>> GetFundsRanking();
        Task<HttpResponseMessage> Import(object data, string route);
    }
}