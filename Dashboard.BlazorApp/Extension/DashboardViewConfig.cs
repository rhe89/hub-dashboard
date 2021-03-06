﻿using Skclusive.Material.Layout;

namespace Dashboard.BlazorApp.Extension
{
    public interface IDashboardViewConfig : ILayoutConfig
    {
    }

    public class DashboardViewConfigBuilder : LayoutConfigBuilder<DashboardViewConfigBuilder, IDashboardViewConfig>
    {
        protected class DashboardViewConfig : LayoutConfig, IDashboardViewConfig
        {
        }

        public DashboardViewConfigBuilder() : base(new DashboardViewConfig())
        {
        }

        protected override IDashboardViewConfig Config()
        {
            return (IDashboardViewConfig)_config;
        }

        protected override DashboardViewConfigBuilder Builder()
        {
            return this;
        }
    }
}
