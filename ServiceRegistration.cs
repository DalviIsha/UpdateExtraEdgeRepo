using Domain.Interfaces.Repositories.RepoWrappers;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Infrastructure.Repositories.RepoWrappers;
using WebApplication1.Infrastructure.Repositories.RepoWrappers.CommandRepo;

namespace WebApplication1.API.Helpers
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductCustomRepo, ProductCustomRepo>();
            services.AddScoped<ISalesQueryRepo, SalesQueryRepo>();
            return services;
        }
    }
}
