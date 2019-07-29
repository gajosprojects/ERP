using ERP.Gerencial.Domain.GruposEmpresariais.Events;
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
            SavedGrupoEmpresarialEvent notification = new SavedGrupoEmpresarialEvent(Guid.NewGuid(), "GE01", "GE01", DateTime.Now, DateTime.Now);
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_UpdatedGrupoEmpresarialEvent_RetornarSucesso()
        {
            UpdatedGrupoEmpresarialEvent notification = new UpdatedGrupoEmpresarialEvent(Guid.NewGuid(), "GE01", "GE01", DateTime.Now);
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }

        [Fact]
        public void GrupoEmpresarialEventHandler_DeletedGrupoEmpresarialEvent_RetornarSucesso()
        {
            DeletedGrupoEmpresarialEvent notification = new DeletedGrupoEmpresarialEvent(Guid.NewGuid());
            Assert.Equal(_grupoEmpresarialEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }
    }
}
