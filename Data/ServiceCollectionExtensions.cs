using Data.Service;
using Data.Service.Interface;

namespace Data
{
    public static class ServiceCollectionExtensions
    {
       
        public static IServiceCollection AddAppDataServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILatencyService, LatencyService>();
            return services;
        }
    }
}
