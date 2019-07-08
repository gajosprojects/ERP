using System;
using ERP.Domain.Core.Events;

namespace ERP.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}