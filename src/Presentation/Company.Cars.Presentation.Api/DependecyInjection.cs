namespace Company.Cars.Presentation.Api
{
    using Company.Cars.Blocks.Common.Swagger.Configuration;
    using Company.Cars.Blocks.Presentation.Api.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Swashbuckle.AspNetCore.Filters;
    using System.Reflection;

    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services, IHostEnvironment environment)
        {
            services
                .AddSwaggerConfiguration();

            services
                .AddRestApiConfiguration(environment)
                .AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
