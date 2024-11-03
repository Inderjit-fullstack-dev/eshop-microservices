namespace Catalog.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
        {
            services.AddCarter();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
