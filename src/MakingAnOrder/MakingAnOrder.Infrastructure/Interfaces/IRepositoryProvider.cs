using System;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IRepositoryProvider : IServiceProvider
    {
        TService GetService<TService>(params object[] constructParams);
    }
}
