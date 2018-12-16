using System.Collections.Generic;
using AutoMapper;
using MakingAnOrder.Infrastructure.Interfaces;

namespace MakingAnOrder.Infrastructure.Util
{
    public class MappingService : IMappingService
    {
        private readonly IMapper mapper;

        public MappingService()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
        }

        public TDestination ConvertTo<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> ConvertCollectionTo<TDestination>(object source)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }

        public void Dispose()
        {
        }
    }
}
