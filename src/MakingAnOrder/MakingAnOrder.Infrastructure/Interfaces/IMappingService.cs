using System;
using System.Collections.Generic;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IMappingService : IDisposable
    {
        TDestination ConvertTo<TDestination>(object source);
        IEnumerable<TDestination> ConvertCollectionTo<TDestination>(object source);
    }
}
