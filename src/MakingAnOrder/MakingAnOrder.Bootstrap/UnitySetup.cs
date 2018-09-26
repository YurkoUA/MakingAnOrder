using System;
using Microsoft.Practices.Unity;
using MakingAnOrder.Infrastructure.Interfaces;

namespace MakingAnOrder.Bootstrap
{
    public static class UnitySetup
    {
        static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static void RegisterTypes(IUnityContainer container)
        {
            UnityDependencyResolver.RegisterTypes(container);
        }

        public static IUnityContainer GetUnityConfig()
        {
            return container.Value;
        }

        public static IServiceProviderFactory CreateFactory(IInternalRequestContext context)
        {
            return new ServiceProviderFactory(container.Value, context);
        }
    }
}