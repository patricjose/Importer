using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Importer.Models;

namespace Importer
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessFunds();
        }

        private static async Task ProcessFunds()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Basic YXBpOlIkX1hKZk1uNVdhaHlKaA==");

            Console.WriteLine("Getting external API information...");

            var streamTask = client.GetStreamAsync("https://maisretorno.com/api/v1/fundos/get/forpus-acoes-master-fia/wallet/details/");
            var walletDetails = await JsonSerializer.DeserializeAsync<WalletDetails>(await streamTask);

            Console.WriteLine("Wallet details found!");
            Console.WriteLine("Building wallet object...");

            var importWallet = new ImportWallet();
            importWallet.id = Guid.NewGuid();
            importWallet.fund = "forpus-acoes-master-fia"; 
            importWallet.assets = new List<Asset>();
            
            foreach (Children c in walletDetails.Wallet.Children)
            {
                if (c.Name == "Ações")
                {
                    importWallet.total = c.Sum;
                    foreach (Children a in c.children)
                    {
                        var asset = new Asset();
                        asset.id = Guid.NewGuid();
                        asset.name = a.Name;
                        asset.size = a.Size;
                        asset.walletId = importWallet.id;

                        importWallet.assets.Add(asset);
                    }
                }
            }

            Console.WriteLine("Serializing object...");
            
            var Json = new StringContent(JsonSerializer.Serialize(importWallet), Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Clear();

            using (var postTask = await client.PostAsync("https://localhost:5001/api/Wallet", Json))
            {
                postTask.EnsureSuccessStatusCode();

                Console.WriteLine(postTask.ToString());
            }
        }
    }
}
