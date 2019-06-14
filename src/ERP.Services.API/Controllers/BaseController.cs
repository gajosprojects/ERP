using System.Linq;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Services.API.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected BaseController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida()) return Ok(new { success = true, data = result });

            return BadRequest(new { success = false, errors = _notifications.GetNotifications().Select(n => n.Value) });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.RaiseEvent(new DomainNotification(codigo, mensagem));
        }

        protected bool IsModelStateValid()
        {
            if (ModelState.IsValid) return true;
            NotificarErroModelInvalida();
            return false;
        }
    }
}