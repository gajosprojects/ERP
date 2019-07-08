using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Events;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Events;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Gerencial.Domain.Usuarios.Commands;
using ERP.Gerencial.Domain.Usuarios.Events;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using ERP.Infra.CrossCutting.AspNetLogs;
using ERP.Infra.CrossCutting.Bus;
using ERP.Infra.CrossCutting.Identity.Models;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.EventSourcing;
using ERP.Infra.Data.Repositories.EventSourcing;
using ERP.Infra.Data.Repositories.Gerencial;
using ERP.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ERP.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<SaveGrupoEmpresarialCommand, bool>, GrupoEmpresarialCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGrupoEmpresarialCommand, bool>, GrupoEmpresarialCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteGrupoEmpresarialCommand, bool>, GrupoEmpresarialCommandHandler>();
            services.AddScoped<IRequestHandler<SaveUsuarioCommand, bool>, UsuarioCommandHandler>();

            // Domain - GruposEmpresariais
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<SavedGrupoEmpresarialEvent>, GrupoEmpresarialEventHandler>();
            services.AddScoped<INotificationHandler<UpdatedGrupoEmpresarialEvent>, GrupoEmpresarialEventHandler>();
            services.AddScoped<INotificationHandler<DeletedGrupoEmpresarialEvent>, GrupoEmpresarialEventHandler>();
            services.AddScoped<INotificationHandler<SavedUsuarioEvent>, UsuarioEventHandler>();

            // Infra - Data
            services.AddScoped<IGruposEmpresariaisRepository, GruposEmpresariaisRepository>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<GruposEmpresariaisContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity
            services.AddScoped<IUser, User>();

            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
        }
    }
}