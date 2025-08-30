using Microsoft.EntityFrameworkCore;
using Misoso.api.Contracts;
using Misoso.api.Repositories;
using Misoso.Api.Data;
using Misoso.Api.Services;
using Misoso.Api.Services.Interfaces;
using System.Data;

namespace Misoso.Api.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(option => option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"ConnectionString: {connectionString}");


            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<ISubtaskItemService, SubtaskItemService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskItemRepository, TaskITemRepository>();
            services.AddScoped<ISubtaskItemRepository, SubtaskItemRepository>();
        }
    }
}
