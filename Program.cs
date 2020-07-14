using System.Threading.Tasks;
using SmartStocksImporter.Business;
using SmartStocksImporter.Models;

namespace SmartStocksImporter
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            FundsImporterBusiness _fundsImporterBusiness = new FundsImporterBusiness();

            var FundList = await _fundsImporterBusiness.GetFundsRanking();

            foreach (ImportFund f in FundList)
            {
                await _fundsImporterBusiness.Import(f, "fund");
                await _fundsImporterBusiness.Import(await _fundsImporterBusiness.GetFundWallet(f.FundName), "wallet");
            }
        }
    }
}
