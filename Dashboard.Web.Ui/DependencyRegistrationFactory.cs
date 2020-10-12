using System;
using Dashboard.Data;
using Dashboard.Integration;
using Dashboard.Services;
using Dashboard.Web.Ui.Areas.Identity;
using Dashboard.Web.Ui.Extension;
using Hub.Web.DependencyRegistration;
using Hub.Web.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Web.Ui
{
    public class DependencyRegistrationFactory : WebDependencyRegistrationFactory
    {
        public new void BuildServiceCollection(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            base.BuildServiceCollection(serviceCollection, configuration);

            AddDbContext(serviceCollection, configuration);
            AddIdentity(serviceCollection);
        }
        
        private void AddDbContext(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DashboardDbContext>(options => options.UseSqlServer(configuration.GetValue<string>("SQL_DB_DASHBOARD"), x => x.MigrationsAssembly("Dashboard.Data")));
        }
        
        private void AddIdentity(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DashboardDbContext>();
            
            serviceCollection.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
        }

        protected override void AddBlazor(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddRazorPages();
            serviceCollection.AddServerSideBlazor();
            serviceCollection.TryAddDashboardViewServices
            (
                new DashboardViewConfigBuilder()
                    .WithIsServer(true)
                    .WithIsPreRendering(false)
                    .WithResponsive(true)
                    .Build()
            );
        }

        protected override void AddHttpClients(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHubHttpClient<ISbankenApiConnector, SbankenApiConnector>(client =>
                client.BaseAddress = new Uri(configuration.GetValue<string>("SBANKEN_API_HOST")));
            
            serviceCollection.AddHttpClient<ICoinbaseApiConnector, CoinbaseApiConnector>(client =>
                client.BaseAddress = new Uri(configuration.GetValue<string>("COINBASE_API_HOST")));
            
            serviceCollection.AddHttpClient<ISpreadsheetApiConnector, SpreadsheetApiConnector>(client =>
                client.BaseAddress = new Uri(configuration.GetValue<string>("SPREADSHEET_API_HOST")));
        }

        protected override void AddServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<ISbankenApiService, SbankenApiService>();
            serviceCollection.AddTransient<ICoinbaseApiService, CoinbaseApiService>();
            serviceCollection.AddTransient<ISpreadsheetApiService, SpreadsheetApiService>();
            serviceCollection.AddTransient<IInvestmentAndSavingsService, InvestmentAndSavingsService>();
            serviceCollection.AddTransient<IDashboardService, DashboardService>();        
        }

    }
}