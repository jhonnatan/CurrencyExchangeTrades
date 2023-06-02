using AutoMapper;

namespace Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.ExchangeTrades.ExchangeTrade, DataAccess.Entities.ExchangeTrade>().ReverseMap();
        }
    }
}
