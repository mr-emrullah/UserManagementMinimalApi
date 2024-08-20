using Carter;
using Microsoft.Extensions.DependencyInjection;
using UserManagementComponentInfrastructure;

namespace UserManagementPresentation.Controllers
{
    public static class PresentationBuilder
    {
        public static IServiceCollection LoadPresentation(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            services.AddCarter();
            services.AddSingleton<UserEndpoints>();
            return services;
        }
    }
}