using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using order_service.Applications;
using order_service.Domains;
using order_service.Infrastructures.Bootstrap.DatabaseModules;
using order_service.Infrastructures.Repositories;

namespace order_service.Infrastructures.Bootstrap
{
    public class Bootstrapper
    {
        private readonly IServiceCollection services;
        private readonly IServiceModule[] modules;

        public Bootstrapper(IServiceCollection services, IServiceModule customDbModule = null)
        {
            this.services = services;
            modules = new[]
            {
                customDbModule ?? new SqliteDatabase()
            };
        }

        public void Bootstrap()
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<OrderService>();
            services.AddScoped<OrderRepository>();
            foreach (IServiceModule serviceModule in modules)
            {
                serviceModule.Load(services);
            }
        }
    }
}