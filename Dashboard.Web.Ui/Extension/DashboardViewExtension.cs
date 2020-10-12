﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Material.Layout;

namespace Dashboard.Web.Ui.Extension
{
    public static class DashboardViewExtension
    {
        public static void TryAddDashboardViewServices(this IServiceCollection services, IDashboardViewConfig config)
        {
            services.TryAddLayoutServices(config);

            services.TryAddSingleton<IDashboardViewConfig>(config);
        }
    }
}