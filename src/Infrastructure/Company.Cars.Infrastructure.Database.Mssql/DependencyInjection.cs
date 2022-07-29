namespace Company.Cars.Infrastructure.Database.Mssql
{
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Infrastructure.Database.Mssql.Internal;
    using Company.Cars.Infrastructure.Database.Mssql.Internal.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDatabaseMssql(this IServiceCollection services, MssqlSettings settings)
        {
            services.AddDbContext<MssqlDbContext>(options => options.UseSqlServer(settings.ConnectionString));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }

    public class MssqlSettings
    {
        public const string Key = nameof(MssqlSettings);

        public string ConnectionString { get; set; } = default!;
    }
}
