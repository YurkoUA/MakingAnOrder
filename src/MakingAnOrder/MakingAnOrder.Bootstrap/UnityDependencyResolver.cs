﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MakingAnOrder.Data;
using MakingAnOrder.Data.Repositories;
using MakingAnOrder.Infrastructure.Database;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Repositories;
using MakingAnOrder.Infrastructure.Util;
using MakingAnOrder.Infrastructure.Services;
using MakingAnOrder.Business.Services;
using MakingAnOrder.Bootstrap.Context;

namespace MakingAnOrder.Bootstrap
{
    public class UnityDependencyResolver
    {
        protected static IUnityContainer container;

        public static void RegisterTypes(IUnityContainer _container)
        {
            container = _container;

            container.RegisterType<IDbContext, DbContext>(new InjectionConstructor(AppConfigurationHelper.GetConnectionString("DefaultConnection")));
            container.RegisterType<IMappingService, MappingService>();

            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();

            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();

            container.RegisterType<IRequestContext, RootContext>();
        }
    }
}
