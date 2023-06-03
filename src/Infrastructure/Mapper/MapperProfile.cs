using AutoMapper;
using Domain.CurrencyExchange.Trades;

namespace Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CurrencyExchangeTrade, DataAccess.Entities.CurrencyExchangeTrade>().ReverseMap();
        }
    }
}
