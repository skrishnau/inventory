using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Orders;
using ViewModel.Enums;
using ViewModel.Utility;

namespace DTO.Core.Inventory
{
    public static class OrderMapper
    {

        public static Order MapToEntity(this OrderModel model, Order entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }

        public static List<OrderModel> MapToModel(this IEnumerable<Order> query)
        {
            return Mappings.Mapper.Map<List<OrderModel>>(query);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="withOrderDetails">Also map order items</param>
        /// <returns></returns>
        public static OrderModel MapToModel(this Order entity, bool withOrderDetails = false, bool withPayments = false)
        {
            if (entity == null)
                return null;
            var model = Mappings.Mapper.Map<OrderModel>(entity);
            if (withOrderDetails)
            {
                model.OrderItems = entity.OrderItems.MapToOrderItemModel();
            }
            if (withPayments)
            {
                model.Payments = entity.Payments.MapToModel();
            }
            return model;
        }
    }

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            
            // from entity to model
            CreateMap<Order, OrderModel>()
                .ForMember(x => x.User, opt => opt.MapFrom(src => src.User == null ? "" : src.User.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.User == null ? "" : src.User.Address))
               .ForMember(x => x.Phone, opt => opt.MapFrom(src => src.User == null ? "" : src.User.Phone))
                .ForMember(x => x.Warehouse,
                            opt => opt.MapFrom(src => src.Warehouse == null ? "" : src.Warehouse.Name))
                .ForMember(x => x.ToWarehouse,
                            opt => opt.MapFrom(src => src.ToWarehouse == null ? "" : src.ToWarehouse.Name))
               .ForMember(x => x.ParentOrder, opt => opt.Ignore())
               .ForMember(x => x.OrderItems, opt => opt.Ignore())
               .ForMember(x => x.Status,
                            opt => opt.MapFrom(src =>
                                        src.IsVoid ? OrderStatusEnum.Void.ToString()
                                        : src.IsCancelled ? OrderStatusEnum.Cancelled.ToString()
                                        : src.IsCompleted ? OrderStatusEnum.Completed.ToString()
                                        : src.IsVerified ? OrderStatusEnum.Pending.ToString()
                                        : OrderStatusEnum.Open.ToString()
                            ))
               .ForMember(x => x.NoOfProducts,
                            opt => opt.MapFrom(src => src.OrderItems.Select(x=>x.ProductId).Distinct().Count()))
                .ForMember(x=>x.UpdatedAtBS, opt => opt.MapFrom(src => DateConverter.Instance.ToBS(src.UpdatedAt)))
                .ForMember(x=>x.DeliveryDateBS, opt => opt.MapFrom(src => DateConverter.Instance.ToBS(src.DeliveryDate)))
                .ForMember(x=>x.CompletedDateBS, opt => opt.MapFrom(src => DateConverter.Instance.ToBS(src.CompletedDate??DateTime.Now)))
               ;

            // from model to entity
            CreateMap<OrderModel, Order>()
                .ForMember(x => x.Warehouse, src => src.Ignore())
                .ForMember(x => x.ToWarehouse, src => src.Ignore())
                .ForMember(x => x.User, src => src.Ignore())
                .ForMember(x => x.ParentOrder, src => src.Ignore())
                .ForMember(x => x.OrderItems, src => src.Ignore())
                .ForMember(x => x.CreatedAt, src => src.Ignore())
                .ForMember(x => x.UserId, opt => opt.MapFrom(src=> src.UserId == 0 ? null : src.UserId))
                .ForMember(x => x.WarehouseId, opt => opt.MapFrom(src=> src.WarehouseId == 0 ? null : src.WarehouseId))
                .ForMember(x => x.ToWarehouseId, opt => opt.MapFrom(src=> src.ToWarehouseId == 0 ? null : src.ToWarehouseId))
                .ForMember(x => x.ParentOrderId, opt => opt.MapFrom(src=> src.ParentOrderId == 0 ? null : src.ParentOrderId))
                ;
        }
    }
}


//public static Order MapToOrderEntityForAdd(OrderModel model, Order entity)
//{
//    if (entity == null)
//    {
//        entity = new Order();
//    }

//    entity.ExpectedDate = model.ExpectedDate;
//    entity.LotNumber = model.LotNumber;
//    entity.Name = model.Name;
//    entity.Note = model.Note;
//    entity.ReferenceNumber = model.ReferenceNumber;
//    entity.SupplierId = model.SupplierId;
//    entity.SupplierInvoice = model.SupplierInvoice;
//    entity.WarehouseId = model.WarehouseId;
//    // don't add other properties which are set individually, e.g. receivedAt, etc.

//    return entity;
//}


//public static List<OrderModel> MapToOrderModel(IQueryable<Order> query)
//{
//    var list = new List<OrderModel>();
//    foreach (var entity in query)
//    {
//        list.Add(MapToOrderModel(entity));
//    }
//    return list;
//}

//public static OrderModel MapToOrderModel(Order entity)
//{
//    var model = new OrderModel();
//    if (entity == null)
//        return null;

//    model.Id = entity.Id;
//    model.LotNumber = entity.LotNumber;
//    model.Note = entity.Note;
//    model.SupplierId = entity.SupplierId;
//    // entity.CreatedAt = model.CreatedAt;
//    model.ExpectedDate = entity.ExpectedDate;
//    model.IsCancelled = entity.IsCancelled;
//    model.CancelledDate = entity.CancelledDate;
//    model.IsExecuted = entity.IsExecuted;
//    model.ExecutedDate = entity.ExecutedDate;
//    model.IsVerified = entity.IsVerified;
//    model.VerifiedDate = entity.VerifiedDate;
//    model.Name = entity.Name;
//    model.ReferenceNumber = entity.ReferenceNumber;
//    // entity.ParentOrder = model.ParentOrder;
//    model.ParentOrderId = entity.ParentOrderId;
//    model.Supplier = entity.Supplier == null ? "" : entity.Supplier.BasicInfo.Name;
//    model.TotalAmount = entity.TotalAmount;
//    //entity.UpdatedAt = model.UpdatedAt;
//    model.Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name;
//    model.WarehouseId = entity.WarehouseId;
//    model.SupplierInvoice = entity.SupplierInvoice;

//    model.OrderItems = OrderItemMapper.MapToPurhaseOrderItemModel(entity.OrderItems.AsQueryable());

//    model.Status = entity.IsCancelled ? OrderStatusEnum.Cancelled.ToString()
//        : entity.IsExecuted ? OrderStatusEnum.Received.ToString()
//        : entity.IsVerified ? OrderStatusEnum.Sent.ToString()
//        : OrderStatusEnum.Open.ToString();

//    return model;
//}