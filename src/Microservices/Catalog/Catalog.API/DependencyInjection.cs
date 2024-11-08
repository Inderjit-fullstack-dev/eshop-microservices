using Marten;
namespace Catalog.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // automapper
            services.AddAutoMapper(typeof(Mappings));


            services.AddCarter();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


            // registering marten


            services.AddMarten(options =>
            {
                options.Connection(configuration.GetConnectionString("Default"));
            }).UseLightweightSessions();

            return services;
        }
    }
}
