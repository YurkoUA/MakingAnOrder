using System;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IServiceProviderFactory : IServiceProvider
    {
        TService GetService<TService>(params object[] constructParams);

        TService GetMappingService<TService>(string name, params object[] param);

        object GetService(Type serviceType, params object[] constructParams);

        TService TryGetMappingService<TService>(string name, params object[] param);
    }
}
