using System;
using Microsoft.Practices.Unity;
using MakingAnOrder.Infrastructure.Interfaces;

namespace MakingAnOrder.Bootstrap
{
    internal sealed class ServiceProviderFactory : IServiceProviderFactory, IDisposable
    {
        private readonly IInternalRequestContext requestContext = default(IInternalRequestContext);

        /// <summary>
        /// Stores cached value of dataContext factory
        /// </summary>
        private readonly ServiceProviderParametersResolver DefaultResolver = default(ServiceProviderParametersResolver);

        /// <summary>
        /// Stores static instance of builder
        /// </summary>
        private readonly IUnityContainer container = new UnityContainer();

        public ServiceProviderFactory(IUnityContainer container, IInternalRequestContext requestContext)
        {
            this.container = container;
            this.requestContext = requestContext;

            this.DefaultResolver = new ServiceProviderParametersResolver(requestContext, null);
        }

        public TService GetMappingService<TService>(string name, params object[] param)
        {
            throw new NotImplementedException();
        }

        public TService GetService<TService>(params object[] constructParams)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType, params object[] constructParams)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService TryGetMappingService<TService>(string name, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
