using markamed_api.Data;
using Microsoft.EntityFrameworkCore;

namespace markamed_api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddMysql(connectionString);
            services.AddScoped(provider => provider.GetRequiredService<AppDbContext>());
            return services;
        }

        private static IServiceCollection AddMysql(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(m => m.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();

            return services;
        }
    }
}