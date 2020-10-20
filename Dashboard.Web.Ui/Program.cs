using Hub.Web.HostBuilder;
using Microsoft.Extensions.Hosting;

namespace Dashboard.Web.Ui
{
    public class Program : WebHostBuilder<Startup, DependencyRegistrationFactory>
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}