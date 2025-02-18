using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParrotIncSquawk.Infrastructure.Persistence;
using ParrotIncSquawk.Infrastructure.Squawks.CreateSquawk;
using ParrotIncSquawk.Infrastructure.Squawks.GetSquawks;

namespace ParrotIncSquawk.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services)
        {
            services.AddDbContext<SquawkContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "SquawkDb");
            });

            services.AddScoped<IGetSquawksRepository, GetSquawksRepository>();
            services.AddScoped<IGetSquawkByIdRepository, GetSquawkByIdRepository>();
            services.AddScoped<ICreateSquawkRepository, CreateSquawkRepository>();
            return services;
        }
    }
}
