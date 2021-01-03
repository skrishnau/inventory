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
    public interface IDatabaseChangeListener
    {
        // branch event and invoker
        event EventHandler<BranchEventArgs> BranchUpdated;
        void TriggerBranchUpdateEvent(object sender, BranchEventArgs eventArgs);

        // category event and invoker
        event EventHandler<CategoryEventArgs> CategoryUpdated;
        void TriggerCategoryUpdateEvent(object sender, CategoryEventArgs eventArgs);

        // category event and invoker
        event EventHandler<ProductEventArgs> ProductUpdated;
        void TriggerProductUpdateEvent(object sender, ProductEventArgs eventArgs);

        // Warehouse
        event EventHandler<BaseEventArgs<WarehouseModel>> WarehouseUpdated;
        void TriggerWarehouseUpdateEvent(object sender, BaseEventArgs<WarehouseModel> eventArgs);
        // supplier
        event EventHandler<BaseEventArgs<SupplierModel>> SupplierUpdated;
        void TriggerSupplierUpdateEvent(object sender, BaseEventArgs<SupplierModel> eventArgs);

        // UOM
        event EventHandler<BaseEventArgs<UomModel>> UomUpdated;
        void TriggerUomUpdateEvent(object sender, BaseEventArgs<UomModel> eventArgs);
        // Package
        event EventHandler<BaseEventArgs<PackageModel>> PackageUpdated;
        void TriggerPackageUpdateEvent(object sender, BaseEventArgs<PackageModel> eventArgs);
        // adj code
        event EventHandler<BaseEventArgs<AdjustmentCodeModel>> AdjustmentCodeUpdated;
        void TriggerAdjustmentCodeUpdateEvent(object sender, BaseEventArgs<AdjustmentCodeModel> eventArgs);
        // Order
        event EventHandler<BaseEventArgs<OrderModel>> OrderUpdated;
        void TriggerOrderUpdateEvent(object sender, BaseEventArgs<OrderModel> eventArgs);
        // Payment
        event EventHandler<BaseEventArgs<PaymentModel>> PaymentUpdated;
        void TriggerPaymentUpdateEvent(object sender, BaseEventArgs<PaymentModel> eventArgs);
        // Inventory Unit Updates
        event EventHandler<BaseEventArgs<List<InventoryUnitModel>>> InventoryUnitUpdated;
        void TriggerInventoryUnitUpdateEvent(object p, BaseEventArgs<List<InventoryUnitModel>> eventArgs);
        // Customer
        event EventHandler<BaseEventArgs<CustomerModel>> CustomerUpdated;
        void TriggerCustomerUpdateEvent(object p, BaseEventArgs<CustomerModel> eventArgs);
    }
}
