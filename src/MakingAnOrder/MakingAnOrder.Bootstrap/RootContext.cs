using System;
using System.Web;
using MakingAnOrder.Infrastructure.Database;
using MakingAnOrder.Infrastructure.Interfaces;

namespace MakingAnOrder.Bootstrap.Context
{
    public class RootContext : HttpContextBase, IRequestContext
    {
        public RootContext()
        {
            Factory = UnitySetup.CreateFactory(this);
            DataContext = Factory.GetService<IDbContext>();
        }

        public string ApplicationPath => ApplicationPath;

        public IDbContext DataContext { get; set; }

        public IServiceProviderFactory Factory { get; set; }

        public void Dispose()
        {
        }
    }
}