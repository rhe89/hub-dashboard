
using Dashboard.Data;
using Hub.Web.BlazorServer;
using Microsoft.Extensions.Hosting;

namespace Dashboard.BlazorApp
{
    public static class Program
    {
        public static void Main(string[] args)
        { 
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return HostBuilder<Startup>.Create(args);
        }
    }
}