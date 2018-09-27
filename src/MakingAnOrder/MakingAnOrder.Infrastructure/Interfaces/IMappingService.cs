using System.Collections.Generic;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IMappingService
    {
        TDestination ConvertTo<TDestination>(object source);
        IEnumerable<TDestination> ConvertCollectionTo<TDestination>(object source);
    }
}
