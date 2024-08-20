using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagementComponentApplication.Commands.Users.CreateUser;
using UserManagementComponentApplication.Commands.Users.DeleteUser;
using UserManagementComponentApplication.Commands.Users.UpdateUser;
using UserManagementComponentApplication.Commands.Validators;
using UserManagementComponentApplication.Interfaces;
using UserManagementComponentApplication.Queries.Users;
using UserManagementComponentInfrastructure.Persistence.Repositories;
using UserManagementComponentApplication.Behaviors; 

namespace UserManagementComponentInfrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var currentAssembly = Assembly.GetAssembly(typeof(GetUsersQuery))!;

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(currentAssembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviors<,>));

            });
            services.AddValidatorsFromAssembly(currentAssembly);

            services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
            services.AddTransient<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
            services.AddSingleton<IUserRepository, UserInMemoryRepository>(); // Singleton yerine Scoped da kullanılabilir

            return services;
        }
    }
}