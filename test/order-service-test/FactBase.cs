using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using order_service.Infrastructures.Bootstrap;
using order_service.Infrastructures.Bootstrap.DatabaseModules;

namespace order_service_test
{
    public class FactBase : IDisposable
    {
        private readonly ServiceProvider Scope;
        public readonly HttpClient httpClient;

        protected FactBase()
        {
            var database = new InMemoryDatabase();
            var services = new ServiceCollection();
            new Bootstrapper(services, database).Bootstrap();

            Scope = services.BuildServiceProvider();
            httpClient = new CustomWebApplicationFactory().CreateClient();
        }

        protected ISession ResolveSession()
        {
            var session = Scope.GetService<ISession>();
            session.Clear();

            return session;
        }

        public void Dispose()
        {
            Scope?.Dispose();
            httpClient?.Dispose();
        }
    }
}