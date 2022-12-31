using Seventh.Infra.IoC;

namespace Seventh.API.Configuration
{
    public static class DIConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);
        }
    }
}