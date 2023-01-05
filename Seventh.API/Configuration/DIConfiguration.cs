using Seventh.API.Filters;
using Seventh.Infra.IoC;

namespace Seventh.API.Configuration
{
    public static class DIConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);
        }

        public static void AddFilter(this IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add<NotificationFilter>());
        }
    }
}