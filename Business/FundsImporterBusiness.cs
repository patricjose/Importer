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
        public async Task GetFundDetails(string fund)
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
                    if (c.name == "Ações")
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

                Console.WriteLine(await ImportWallet(importWallet));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task GetFundsRanking()
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

                var stocksFundList = new List<Fund>();

                foreach (Fund f in fundList)
                {
                    if (f.cvm_class != null && f.cvm_class.ToUpper().Equals("AÇÕES"))
                        stocksFundList.Add(f);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> ImportWallet (object data)
        {
            var httpClientUtil = new HttpClientUtil();
            var client = httpClientUtil.InitializeClient();

            Console.WriteLine("Serializing object...");
            
            var Json = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            Console.WriteLine(JsonSerializer.Serialize(data));

            using (var postTask = await client.PostAsync("https://localhost:5001/api/Wallet", Json))
            {
                return postTask.EnsureSuccessStatusCode();
            }
        }
    }
}