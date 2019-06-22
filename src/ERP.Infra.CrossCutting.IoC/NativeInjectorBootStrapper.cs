using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Events;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Events;
using ERP.Domain.Core.Notifications;
using ERP.Infra.CrossCutting.Bus;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.EventSourcing;
using ERP.Infra.Data.Repositories.Gerencial;
using ERP.Infra.Data.Repositories.EventSourcing;
using ERP.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<SaveGrupoEmpresarialCommand, bool>, GrupoEmpresarialCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGrupoEmpresarialCommand, bool>, GrupoEmpresarialCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteGrupoEmpresarialCommand, bool>, GrupoEmpresarialCommandHandler>();

            // Domain - GruposEmpresariais
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<SavedGrupoEmpresarialEvent>, GrupoEmpresarialEventHandler>();
            services.AddScoped<INotificationHandler<UpdatedGrupoEmpresarialEvent>, GrupoEmpresarialEventHandler>();
            services.AddScoped<INotificationHandler<DeletedGrupoEmpresarialEvent>, GrupoEmpresarialEventHandler>();

            // Infra - Data
            services.AddScoped<IGruposEmpresariaisRepository, GruposEmpresariaisRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<GruposEmpresariaisContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}