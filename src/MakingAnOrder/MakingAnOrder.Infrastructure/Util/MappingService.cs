using System.Collections.Generic;
using AutoMapper;
using MakingAnOrder.Infrastructure.Interfaces;

namespace MakingAnOrder.Infrastructure.Util
{
    public class MappingService : IMappingService
    {
        private readonly IMapper mapper;

        public MappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination ConvertTo<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> ConvertCollectionTo<TDestination>(object source)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}
