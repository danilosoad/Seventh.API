using Microsoft.Extensions.DependencyInjection;
using Seventh.Application.Services;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Servers.Validation;
using Seventh.Infra.Data.DataContext;
using Seventh.Infra.Data.Repository;

namespace Seventh.Infra.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IServerService, ServerService>();

            //Data
            services.AddScoped<Context>();
            services.AddScoped<ServerValidation>();
            services.AddScoped<IServerRepository, ServerRepository>();
        }
    }
}