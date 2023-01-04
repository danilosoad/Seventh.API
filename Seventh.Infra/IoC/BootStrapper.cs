using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seventh.Application.Commands.Video;
using Seventh.Application.Handlers.Videos;
using Seventh.Application.Queries.Videos;
using Seventh.Application.Responses;
using Seventh.Application.Services;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Servers.Validation;
using Seventh.Infra.Data.DataContext;
using Seventh.Infra.Data.Repository;
using System.Reflection;

namespace Seventh.Infra.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Services
            services.AddScoped<IServerService, ServerService>();

            //Data
            services.AddScoped<Context>();
            services.AddScoped<ServerValidation>();
            services.AddScoped<IServerRepository, ServerRepository>();

            //Jobs
            services.AddHangfire(configuration => configuration.UseMemoryStorage());
            services.AddHangfireServer();

            //Commands
            services.AddScoped<IRequestHandler<AddVideoCommand, AddVideoResponse>, AddVideoCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<GetAllVideosByServerQuery, GetAllVideosByServerResponse>, GetAllVideosByServerQueryHandler>();
            services.AddScoped<IRequestHandler<GetVideoByIdQuery, GetVideoByIdResponse>, GetVideoByIdQueryHandler>();
        }
    }
}