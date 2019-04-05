using Service.Listeners.Business;
using Service.Listeners.Inventory;
using System;

namespace Service.Listeners
{
    public class DatabaseChangeListener:IDatabaseChangeListener
    {
        // ======================= Events ======================== //
        public event EventHandler<BranchEventArgs> BranchUpdated;
        public event EventHandler<CategoryEventArgs> CategoryUpdated;
        public event EventHandler<ProductEventArgs> ProductUpdated;


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
    }
}
