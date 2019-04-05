using Service.Listeners.Business;
using Service.Listeners.Inventory;
using System;

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
    }
}
