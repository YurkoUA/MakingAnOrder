using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using MakingAnOrder.Infrastructure.Interfaces;

namespace MakingAnOrder.Bootstrap
{
    internal class ServiceProviderParametersResolver : ResolverOverride
    {
        private readonly Queue<InjectionParameterValue> parameterValues;

        public ServiceProviderParametersResolver(IInternalRequestContext requestContext, IEnumerable<object> values, bool useContext = false)
        {
            parameterValues = new Queue<InjectionParameterValue>();

            if (useContext)
            {
                parameterValues.Enqueue(InjectionParameterValue.ToParameter(requestContext));
            }

            if (values != null)
            {
                foreach (var parameterValue in values)
                    parameterValues.Enqueue(InjectionParameterValue.ToParameter(parameterValue));
            }
        }

        public override IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
        {
            if (parameterValues.Count < 1)
                return null;

            var value = parameterValues.Dequeue();
            return value.GetResolverPolicy(dependencyType);
        }
    }
}
