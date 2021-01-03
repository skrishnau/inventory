using Service.DbEventArgs;
using Service.Listeners.Business;
using Service.Listeners.Inventory;
using System;
using System.Collections.Generic;
using ViewModel.Core.Business;
using ViewModel.Core.Customers;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Core.Suppliers;

namespace Service.Listeners
{
    public class DatabaseChangeListener:IDatabaseChangeListener
    {
        // ======================= Events ======================== //
        public event EventHandler<BranchEventArgs> BranchUpdated;
        public event EventHandler<CategoryEventArgs> CategoryUpdated;
        public event EventHandler<ProductEventArgs> ProductUpdated;
        public event EventHandler<BaseEventArgs<WarehouseModel>> WarehouseUpdated;
        public event EventHandler<BaseEventArgs<SupplierModel>> SupplierUpdated;
        public event EventHandler<BaseEventArgs<UomModel>> UomUpdated;
        public event EventHandler<BaseEventArgs<PackageModel>> PackageUpdated;
        public event EventHandler<BaseEventArgs<AdjustmentCodeModel>> AdjustmentCodeUpdated;
        public event EventHandler<BaseEventArgs<OrderModel>> OrderUpdated;
        public event EventHandler<BaseEventArgs<PaymentModel>> PaymentUpdated;
        public event EventHandler<BaseEventArgs<OrderModel>> OrderItemUpdated;
        public event EventHandler<BaseEventArgs<List<InventoryUnitModel>>> InventoryUnitUpdated;
        public event EventHandler<BaseEventArgs<CustomerModel>> CustomerUpdated;


        // ======================== Invoker ========================== //
        //--- expose functions to facilitate the event trigger from another class --- // 

        public void TriggerBranchUpdateEvent(object sender, BranchEventArgs eventArgs)
        {
            // call the event
            BranchUpdated?.Invoke(sender, eventArgs);
        }

        // category
        public void TriggerCategoryUpdateEvent(object sender, CategoryEventArgs args)
        {
            CategoryUpdated?.Invoke(sender, args);
        }

        public void TriggerProductUpdateEvent(object sender, ProductEventArgs eventArgs)
        {
            ProductUpdated?.Invoke(sender, eventArgs);
        }

        public void TriggerSupplierUpdateEvent(object sender, BaseEventArgs<SupplierModel> eventArgs)
        {
            SupplierUpdated?.Invoke(sender, eventArgs);
        }

        public void TriggerUomUpdateEvent(object sender, BaseEventArgs<UomModel> eventArgs)
        {
            UomUpdated?.Invoke(sender, eventArgs);
        }

        public void TriggerPackageUpdateEvent(object sender, BaseEventArgs<PackageModel> eventArgs)
        {
            PackageUpdated?.Invoke(sender, eventArgs);
        }

        public void TriggerWarehouseUpdateEvent(object sender, BaseEventArgs<WarehouseModel> eventArgs)
        {
            WarehouseUpdated?.Invoke(sender, eventArgs);
        }

        public void TriggerAdjustmentCodeUpdateEvent(object sender, BaseEventArgs<AdjustmentCodeModel> eventArgs)
        {
            AdjustmentCodeUpdated?.Invoke(sender, eventArgs);
        }

        public void TriggerOrderUpdateEvent(object p, BaseEventArgs<OrderModel> eventArgs)
        {
            OrderUpdated?.Invoke(p, eventArgs);
        }

        public void TriggerPaymentUpdateEvent(object p, BaseEventArgs<PaymentModel> eventArgs)
        {
            PaymentUpdated?.Invoke(p, eventArgs);
        }

        public void TriggerOrderItemUpdateEvent(object p, BaseEventArgs<OrderModel> eventArgs)
        {
            OrderItemUpdated?.Invoke(p, eventArgs);
        }

        public void TriggerInventoryUnitUpdateEvent(object p, BaseEventArgs<List<InventoryUnitModel>> eventArgs)
        {
            InventoryUnitUpdated?.Invoke(p, eventArgs);
        }

        public void TriggerCustomerUpdateEvent(object p, BaseEventArgs<CustomerModel> eventArgs)
        {
            CustomerUpdated?.Invoke(p, eventArgs);
        }
    }
}
