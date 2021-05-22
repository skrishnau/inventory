using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System.Collections.Generic;
using ViewModel.Core;

namespace DTO.Core
{
    public static class TransactionMapper
    {
        public static Transaction MapToEntity(this TransactionModel model, Transaction entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static TransactionModel MapToModel(this Transaction entity, TransactionModel model)
        {
            return Mappings.Mapper.Map(entity, model);
        }
        public static List<TransactionModel> MapToModel(this IEnumerable<Transaction> query)
        {
            return Mappings.Mapper.Map<List<TransactionModel>>(query);
        }

    }


    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionModel>()
                .ForMember(s => s.User, opt => opt.MapFrom(src => src.User == null ? "" : src.User.Name))
                .ForMember(s => s.Order, opt => opt.MapFrom(src => src.Order == null ? "" : src.Order.ReferenceNumber))
                ;
            CreateMap<TransactionModel, Transaction>()
                .ForMember(s => s.User, opt => opt.Ignore())
                .ForMember(s => s.Order, opt => opt.Ignore())
                ;
        }
    }
}
