using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SmartStocksImporter.Models;
using SmartStocksImporter.Utils;

namespace SmartStocksImporter.Business
{
    class FundsImporterBusiness : IFundsImporterBusiness
    {
        public async Task<ImportWallet> GetFundWallet(string fund)
        {
            try {
                var httpClientUtil = new HttpClientUtil();
                var client = httpClientUtil.InitializeClient();
                
                client.DefaultRequestHeaders.Add("Authorization", "Basic YXBpOlIkX1hKZk1uNVdhaHlKaA==");

                Console.WriteLine("Getting external API information...");

                var streamTask = client.GetStreamAsync("https://maisretorno.com/api/v1/fundos/get/"+ fund +"/wallet/details/");
                var walletDetails = await JsonSerializer.DeserializeAsync<WalletDetails>(await streamTask);

                Console.WriteLine("Wallet details found!");
                Console.WriteLine("Building wallet object...");

                var importWallet = new ImportWallet();
                importWallet.Id = Guid.NewGuid();
                importWallet.Fund = fund; 
                importWallet.Assets = new List<Asset>();
                
                foreach (Children c in walletDetails.wallet.children)
                {
                    if (c.name.ToUpper().Equals("AÇÕES") || c.name.ToUpper().Equals("INVESTIMENTO NO EXTERIOR"))
                    {
                        importWallet.Total = c.sum;
                        foreach (Children a in c.children)
                        {
                            var asset = new Asset();
                            asset.Id = Guid.NewGuid();
                            asset.Name = a.name;
                            asset.Size = a.size;
                            asset.WalletId = importWallet.Id;

                            importWallet.Assets.Add(asset);
                        }
                    }
                }

                Console.WriteLine(importWallet);

                return importWallet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<ImportFund>> GetFundsRanking()
        {
            try
            {
                var httpClientUtil = new HttpClientUtil();
                var client = httpClientUtil.InitializeClient();
                
                client.DefaultRequestHeaders.Add("Authorization", "Basic YXBpOlIkX1hKZk1uNVdhaHlKaA==");

                Console.WriteLine("Getting external API information...");

                var streamTask = client.GetStreamAsync("https://maisretorno.com/api/v1/fundos/ranking/");
                var fundList = await JsonSerializer.DeserializeAsync<List<Fund>>(await streamTask);

                Console.WriteLine("Ranking details found!");
                Console.WriteLine("Building fund object list...");

                var stocksFundList = new List<ImportFund>();

                foreach (Fund f in fundList)
                {
                    if (f.cvm_class != null && f.cvm_class.ToUpper().Equals("AÇÕES"))
                    {
                        var fund = new ImportFund();
                        fund.Class = f.cvm_class;
                        fund.FundName = f.s;
                        fund.Type = f.tipo;
                        fund.Variation6Months = f.variacao_6_meses;

                        stocksFundList.Add(fund);
                    }
                }

                return stocksFundList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> Import (object data, string route)
        {
            var httpClientUtil = new HttpClientUtil();
            var client = httpClientUtil.InitializeClient();

            Console.WriteLine("Serializing object...");
            
            var Json = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            Console.WriteLine(JsonSerializer.Serialize(data));

            using (var postTask = await client.PostAsync("https://localhost:5001/api/" + route, Json))
            {
                return postTask.EnsureSuccessStatusCode();
            }
        }
    }
}