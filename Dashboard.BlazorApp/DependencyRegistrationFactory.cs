using System;
using Dashboard.BlazorApp.Areas.Identity;
using Dashboard.BlazorApp.Extension;
using Dashboard.BlazorApp.Services;
using Dashboard.Data;
using Dashboard.Integration;
using Hub.Web.BlazorServer;
using Hub.Web.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.BlazorApp
{
    public class DependencyRegistrationFactory : DependencyRegistrationFactoryBase
    {
        protected override void AddBlazorExtras(IServiceCollection serviceCollection, IConfiguration configuration)
        {
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

        protected override void AddDomainDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DashboardDbContext>(options => options.UseSqlServer(configuration.GetValue<string>("SQL_DB_DASHBOARD"), x => x.MigrationsAssembly("Dashboard.Data")));

            serviceCollection.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DashboardDbContext>();
            
            serviceCollection.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            serviceCollection.AddTransient<ISbankenApiService, SbankenApiService>();
            serviceCollection.AddTransient<ICoinbaseApiService, CoinbaseApiService>();
            serviceCollection.AddTransient<ISpreadsheetApiService, SpreadsheetApiService>();
            serviceCollection.AddTransient<IInvestmentAndSavingsService, InvestmentAndSavingsService>();
            serviceCollection.AddTransient<IDashboardService, DashboardService>();        
        }

    }
}