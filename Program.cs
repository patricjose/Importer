using System.Threading.Tasks;
using SmartStocksImporter.Business;

namespace SmartStocksImporter
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string fund = "forpus-acoes-master-fia";

            FundsImporterBusiness _fundsImporterBusiness = new FundsImporterBusiness();

            await _fundsImporterBusiness.GetFundDetails(fund);
            await _fundsImporterBusiness.GetFundsRanking();
        }
    }
}
