using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seventh.Application.Commands.Recycles;
using Seventh.Application.Commands.Servers;
using Seventh.Application.Commands.Videos;
using Seventh.Application.Handlers.Recycles;
using Seventh.Application.Handlers.Servers;
using Seventh.Application.Handlers.Videos;
using Seventh.Application.Queries.Recycles;
using Seventh.Application.Queries.Server;
using Seventh.Application.Queries.Videos;
using Seventh.Application.Responses;
using Seventh.Application.Responses.Recycles;
using Seventh.Application.Responses.Server;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Servers.Validation;
using Seventh.Domain.Notifications;
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

            //Data
            services.AddScoped<Context>();
            services.AddScoped<ServerValidation>();
            services.AddScoped<IServerRepository, ServerRepository>();

            //Jobs
            services.AddHangfire(configuration => configuration.UseMemoryStorage());
            services.AddHangfireServer();

            //Commands
            services.AddScoped<IRequestHandler<AddVideoCommand, AddVideoCommandResponse>, AddVideoCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteVideoCommand, DeleteVideoCommandResponse>, DeleteVideoCommandHandler>();
            services.AddScoped<IRequestHandler<RecycleVideoCommand, RecycleVideoCommandResponse>, RecycleVideoCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<GetAllVideosByServerQuery, GetAllVideosByServerQueryResponse>, GetAllVideosByServerQueryHandler>();
            services.AddScoped<IRequestHandler<GetVideoByIdQuery, GetVideoByIdQueryResponse>, GetVideoByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetVideoContentByIdQuery, GetVideoContentByIdQueryResponse>, GetVideoContentByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllServersQuery, GetAllServersQueryResponse>, GetAllServersQueryHandler>();
            services.AddScoped<IRequestHandler<ServerIsAvailableQuery, bool>, ServerIsAvailableQueryHandler>();
            services.AddScoped<IRequestHandler<GetServersByIdQuery, GetAllServersByIdQueryResponse>, GetServersByIdQueryHandler>();
            services.AddScoped<IRequestHandler<AddServerCommand, AddServerCommandResponse>, AddServerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateServerCommand, UpdateServerCommandResponse>, UpdateServerCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteServerCommand, DeleteServerCommandResponse>, DeleteServerCommandHandler>();
            services.AddScoped<IRequestHandler<GetRecycleStatusQuery, GetRecycleStatusQueryResponse>, GetRecycleStatusQueryHandler>();

            //Notifications
            services.AddScoped<NotificationContext>();
        }
    }
}