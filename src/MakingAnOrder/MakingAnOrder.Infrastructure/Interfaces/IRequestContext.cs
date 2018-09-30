using System;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IRequestContext : IInternalRequestContext, IDisposable
    {
        string ApplicationPath { get; }
    }
}
