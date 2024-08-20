using Microsoft.Extensions.DependencyInjection;
using UserManagementComponent;

namespace UserManagementComponent
{
    public static class ComponentBuilder
    {
        public static IServiceCollection LoadComponent(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserInMemoryRepository>();

            return services;
        }
    }
}