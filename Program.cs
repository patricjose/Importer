using System.Threading.Tasks;
using SmartStocksImporter.Business;
using SmartStocksImporter.Models;

namespace SmartStocksImporter
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string fund = "forpus-acoes-master-fia";

            FundsImporterBusiness _fundsImporterBusiness = new FundsImporterBusiness();

            //await _fundsImporterBusiness.GetFundWallet(fund);
            var FundList = await _fundsImporterBusiness.GetFundsRanking();

            foreach (Fund f in FundList)
                await _fundsImporterBusiness.ImportWallet(await _fundsImporterBusiness.GetFundWallet(f.s));
        }
    }
}
