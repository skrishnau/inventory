using Service.DbEventArgs;
using Service.Listeners.Business;
using Service.Listeners.Inventory;
using System;
using ViewModel.Core.Business;
using ViewModel.Core.Inventory;
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

        public void TriggerWarehouseUpdateEvent(object sender, BaseEventArgs<WarehouseModel> eventArgs)
        {
            WarehouseUpdated?.Invoke(sender, eventArgs);
        }
    }
}
