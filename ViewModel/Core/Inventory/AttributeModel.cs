using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Inventory;

namespace ViewModel.Core.Inventory
{
    public class AttributeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Infrastructure.Entities.Inventory.Attribute ToEntity()
        {
            //return null;
            return new Infrastructure.Entities.Inventory.Attribute
            {
                CreatedAt = CreatedAt,
                DeletedAt = DeletedAt,
                 Id = Id,
                 Name = Name,
                 Value = Value,
                 UpdatedAt = UpdatedAt
            };
        }
    }
}
