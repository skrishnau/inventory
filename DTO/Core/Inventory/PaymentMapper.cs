using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Orders;

namespace DTO.Core.Inventory
{
    public static class PaymentMapper
    {
        public static Payment MapToEntity(this PaymentModel model)
        {
            return Mappings.Mapper.Map<Payment>(model);
        }
        public static Payment MapToEntity(this PaymentModel model, Payment entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }

        public static List<PaymentModel> MapToModel(this IQueryable<Payment> query)
        {
            return Mappings.Mapper.Map<IQueryable<Payment>, List<PaymentModel>>(query);
        }

        public static List<PaymentModel> MapToModel(this ICollection<Payment> query)
        {
            return Mappings.Mapper.Map<ICollection<Payment>, List<PaymentModel>>(query);
        }

        public static PaymentModel MapToModel(this Payment entity)
        {
            return Mappings.Mapper.Map<PaymentModel>(entity);
        }
    }

    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentModel>()
                .ForMember(s=> s.User, opt=>opt.MapFrom(src=>src.User == null ? "" : src.User.Name))
                .ForMember(s=> s.Company, opt=>opt.MapFrom(src=>src.User == null ? "" : src.User.Company))
               // .ForMember(s=> s.Order, opt=>opt.MapFrom(src=>src.Order == null ? "" : src.Order.Name))
                ;
            CreateMap<PaymentModel, Payment>()
                .ForMember(s => s.User, opt => opt.Ignore())
            // .ForMember(s => s.Order, opt => opt.Ignore())
            ;
        }
    }
}
