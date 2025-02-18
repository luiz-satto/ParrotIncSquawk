using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using ParrotIncSquawk.UseCases;
using System.Security.Claims;
using System.Threading.RateLimiting;

namespace ParrotIncSquawk
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(Program).Assembly;
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddValidatorsFromAssembly(assembly);

            // Limited to one post per 20-second interval
            services.AddRateLimiter(_ => _
                .AddFixedWindowLimiter(policyName: Consts.TwentySecondIntervalPolicy, options =>
                {
                    options.PermitLimit = 1;
                    options.Window = TimeSpan.FromSeconds(20);
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 1;
                }));

            services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IAddSquawkUseCase, AddSquawkUseCase>();
            services.AddScoped<IGetSquawksUseCase, GetSquawksUseCase>();
            return services;
        }

        public static WebApplication UseApplicationServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRateLimiter();
            app.UseExceptionHandler(options => { });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapDefaultControllerRoute().RequireRateLimiting(Consts.TwentySecondIntervalPolicy);
            return app;
        }
    }
}
