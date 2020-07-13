using System.Net.Http;
using System.Threading.Tasks;

namespace SmartStocksImporter.Business
{
    public interface IFundsImporterBusiness
    {
        Task GetFundDetails(string fund);
        Task GetFundsRanking();
        Task<HttpResponseMessage> ImportWallet(object data);
    }
}