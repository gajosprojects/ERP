using System;

namespace ERP.Domain.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
         bool Commit();
    }
}