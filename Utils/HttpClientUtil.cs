using System.Net.Http;

namespace SmartStocksImporter.Utils
{
    public class HttpClientUtil
    {
        public HttpClient InitializeClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }
    }
}