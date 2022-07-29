namespace Company.Cars.Infrastructure.Database.Mssql.Internal
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.Reflection;

    internal sealed class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    internal sealed class MssqlDatabaseContextFactory : DatabaseContextFactoryBase<MssqlDbContext>
    {
    }

    public abstract class DatabaseContextFactoryBase<T> : IDesignTimeDbContextFactory<T>
       where T : DbContext
    {
        public T CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = BuildConfiguration(args);

            var optionsBuilder = new DbContextOptionsBuilder<T>();
            var connectionString = configuration.GetSection(args[0]).Value;

            optionsBuilder
                .UseSqlServer(connectionString);

            var instance = Activator.CreateInstance(typeof(T), optionsBuilder.Options);

            if (instance is null)
            {
                throw new InvalidOperationException($"Unable to initialize {nameof(T)} instance.");
            }

            return (T)instance;
        }

        private IConfigurationRoot BuildConfiguration(string[] args)
        {
            var location = Assembly.GetExecutingAssembly().Location;

            string? directory = Path.GetDirectoryName(location);

            return new ConfigurationBuilder()
                .SetBasePath(args[2])
                .AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(args[1])
                .AddCommandLine(args)
                .Build();
        }
    }
}
