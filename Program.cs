using System;
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
                Console.WriteLine("Sending fund data to Smart Stocks API...");

                await _fundsImporterBusiness.Import(f, "fund");

                Console.WriteLine("Done!");
                Console.WriteLine("Sending wallet data to Smart Stocks API...");

                await _fundsImporterBusiness.Import(await _fundsImporterBusiness.GetFundWallet(f.FundName), "wallet");

                Console.WriteLine("Done!");
            }
        }
    }
}
