using Infrastructure.Entities.Users;
using System;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// One product is supplied by many suppliers & one supplier supplies many products
    /// </summary>
    public class ProductSupplier
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SupplierId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        
        
        // ------ table objects ------ //

        public virtual Product Product { get; set; }

        public virtual User Supplier { get; set; }
    }
}
