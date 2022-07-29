namespace Company.Cars
{
    using Company.Cars.Application;
    using Company.Cars.Blocks.Common.Mapping.Configuration;
    using Company.Cars.Blocks.Common.Serilog.Configuration;
    using Company.Cars.Blocks.Common.Swagger.Configuration;
    using Company.Cars.Blocks.Presentation.Api.Configuration;
    using Company.Cars.Infrastructure.Database.Mssql;
    using Company.Cars.Presentation.Api;
    using Hellang.Middleware.ProblemDetails;

    public sealed class Startup
    {
        private MssqlSettings MssqlSettings
            => this.Configuration.GetSection(MssqlSettings.Key).Get<MssqlSettings>();

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddHealthChecks();
            services.AddApplicationLayer();
            services.AddPresentationLayer(this.Environment);
            services.AddInfrastructureDatabaseMssql(this.MssqlSettings);
            services.AddAutoMapperConfiguration(AppDomain.CurrentDomain);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseProblemDetails();

            if (!this.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSerilogConfiguration();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapDefaultHealthCheckRoute();
            });
        }
    }
}
