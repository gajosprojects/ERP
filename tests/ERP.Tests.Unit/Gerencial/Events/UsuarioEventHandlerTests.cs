using ERP.Gerencial.Domain.Usuarios.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.Events
{
    public class UsuarioEventHandlerTests
    {
        public UsuarioEventHandler _usuarioEventHandler;

        public UsuarioEventHandlerTests()
        {
            _usuarioEventHandler = new UsuarioEventHandler();
        }

        [Fact]
        public void UsuarioEventHandler_SavedUsuarioEvent_RetornarSucesso()
        {
            SavedUsuarioEvent notification = new SavedUsuarioEvent(Guid.NewGuid(), "Bar", "Ism", "bar.ism@gmail.com");
            Assert.Equal(_usuarioEventHandler.Handle(notification, new CancellationToken()), Task.CompletedTask);
        }
    }
}
