using Service.DbEventArgs;
using Service.Listeners.Business;
using Service.Listeners.Inventory;
using System;
using ViewModel.Core.Business;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;
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
        // purchase Order
        event EventHandler<BaseEventArgs<PurchaseOrderModel>> PurchaseOrderUpdated;
        void TriggerPurchaseOrderUpdateEvent(object p, BaseEventArgs<PurchaseOrderModel> eventArgs);
    }
}
