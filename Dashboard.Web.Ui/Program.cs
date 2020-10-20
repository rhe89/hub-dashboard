using Hub.Web.HostBuilder;
using Microsoft.Extensions.Hosting;

namespace Dashboard.Web.Ui
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new  WebHostBuilder<Startup, DependencyRegistrationFactory>().CreateHostBuilder(args).Build().Run();
        }
    }
}