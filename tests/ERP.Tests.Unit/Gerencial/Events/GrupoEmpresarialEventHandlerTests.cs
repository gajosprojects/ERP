using ERP.Gerencial.Domain.GruposEmpresariais.Events;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.Events
{
    public class GrupoEmpresarialEventHandlerTests
    {
        public GrupoEmpresarialEventHandler _grupoEmpresarialEventHandler;

        public GrupoEmpresarialEventHandlerTests()
        {
            _grupoEmpresarialEventHandler = new GrupoEmpresarialEventHandler();
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_SavedGrupoEmpresarialEvent_RetornarSucesso()
        {
            SavedGrupoEmpresarialEvent notification = new SavedGrupoEmpresarialEvent(Guid.NewGuid(), "GE01", "GE01", DateTime.Now, DateTime.Now, true, Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_UpdatedGrupoEmpresarialEvent_RetornarSucesso()
        {
            UpdatedGrupoEmpresarialEvent notification = new UpdatedGrupoEmpresarialEvent(Guid.NewGuid(), "GE01", "GE01", DateTime.Now, DateTime.Now, true, Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_DeletedGrupoEmpresarialEvent_RetornarSucesso()
        {
            DeletedGrupoEmpresarialEvent notification = new DeletedGrupoEmpresarialEvent(Guid.NewGuid(), Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_SavedCnaeEvent_RetornarSucesso()
        {
            SavedCnaeEvent notification = new SavedCnaeEvent(Guid.NewGuid(), true, Guid.NewGuid(), DateTime.Now, DateTime.Now, "Cnae1", "Cnae1", Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_UpdatedCnaeEvent_RetornarSucesso()
        {
            UpdatedCnaeEvent notification = new UpdatedCnaeEvent(Guid.NewGuid(), true, Guid.NewGuid(), DateTime.Now, DateTime.Now, "Cnae1", "Cnae1", Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_DeletedCnaeEvent_RetornarSucesso()
        {
            DeletedCnaeEvent notification = new DeletedCnaeEvent(Guid.NewGuid(), Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_SavedEmpresaEvent_RetornarSucesso()
        {
            SavedEmpresaEvent notification = new SavedEmpresaEvent(Guid.NewGuid(), true, Guid.NewGuid(), DateTime.Now, DateTime.Now, "Empresa1", "Empresa1", "Empresa1", "empresa@gmail.com", "empresa.com.br", false, DateTime.Now, null, "", "", 1, Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_UpdatedEmpresaEvent_RetornarSucesso()
        {
            UpdatedEmpresaEvent notification = new UpdatedEmpresaEvent(Guid.NewGuid(), true, Guid.NewGuid(), DateTime.Now, DateTime.Now, "Empresa1", "Empresa1", "Empresa1", "empresa@gmail.com", "empresa.com.br", false, DateTime.Now, null, "", "", 1, Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_DeletedEmpresaEvent_RetornarSucesso()
        {
            DeletedEmpresaEvent notification = new DeletedEmpresaEvent(Guid.NewGuid(), Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_SavedEstabelecimentoEvent_RetornarSucesso()
        {
            SavedEstabelecimentoEvent notification = new SavedEstabelecimentoEvent(Guid.NewGuid(), true, Guid.NewGuid(), DateTime.Now, DateTime.Now, "Estabelecimento1", "Estabelecimento1", "Estabelecimento1", "0123456789", "0123456789", "estabelecimento@gmail.com", "estabelecimento.com.br", false, DateTime.Now, null, true, "", "", 1, Guid.NewGuid(), Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_UpdatedEstabelecimentoEvent_RetornarSucesso()
        {
            UpdatedEstabelecimentoEvent notification = new UpdatedEstabelecimentoEvent(Guid.NewGuid(), true, Guid.NewGuid(), DateTime.Now, DateTime.Now, "Estabelecimento1", "Estabelecimento1", "Estabelecimento1", "0123456789", "0123456789", "estabelecimento@gmail.com", "estabelecimento.com.br", false, DateTime.Now, null, true, "", "", 1, Guid.NewGuid(), Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_DeletedEstabelecimentoEvent_RetornarSucesso()
        {
            DeletedEstabelecimentoEvent notification = new DeletedEstabelecimentoEvent(Guid.NewGuid(), Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }
    }
}
