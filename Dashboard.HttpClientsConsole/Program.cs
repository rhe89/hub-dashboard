using System;
using System.Net.Http;
using Dashboard.HttpClients;
using Microsoft.Extensions.Logging;

namespace Dashboard.HttpClientsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            
            client.BaseAddress = new Uri("https://localhost:44302");

            var sbankenClient = new SbankenApiClient(client, new Logger<SbankenApiClient>(new LoggerFactory()));

            var result = sbankenClient.GetTransactions(30).GetAwaiter().GetResult();
        }
    }
}