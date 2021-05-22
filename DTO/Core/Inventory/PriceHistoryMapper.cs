using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using ViewModel.Utility;

namespace DTO.Core.Inventory
{
    public static class PriceHistoryMapper
    {

        public static PriceHistory MapToEntity(this PriceHistoryModel model, PriceHistory entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }

        public static List<PriceHistoryModel> MapToPriceHistoryModel(this IQueryable<PriceHistory> PriceHistorys)
        {
            return Mappings.Mapper.Map<List<PriceHistoryModel>>(PriceHistorys.ToList());
        }

        public static PriceHistoryModel MapToPriceHistoryModel(this PriceHistory PriceHistory)
        {
            return Mappings.Mapper.Map<PriceHistoryModel>(PriceHistory);
          
        }
    }

    class PriceHistoryProfile : Profile
    {
        public PriceHistoryProfile()
        {
            CreateMap<PriceHistory, PriceHistoryModel>()
                .ForMember(dest => dest.DateString, opt => opt.MapFrom(src => DateConverter.Instance.ToBS(src.Date)))
                .ForMember(dest => dest.Rate, opt=>opt.MapFrom(src=>src.Rate == 0 ? null : (decimal?)src.Rate));
            CreateMap<PriceHistoryModel, PriceHistory>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate == null ? 0 : src.Rate));
        }
    }
}
