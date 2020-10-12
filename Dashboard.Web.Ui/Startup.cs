using Dashboard.Data;
using Microsoft.Extensions.Configuration;
using Hub.Web.Startup;

namespace Dashboard.Web.Ui
{
    public class Startup : WebWithDatabaseStartup<DependencyRegistrationFactory, DashboardDbContext>
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}