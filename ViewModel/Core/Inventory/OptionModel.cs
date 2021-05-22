using System.Collections.Generic;

namespace ViewModel.Core.Inventory
{
    /*public class AttributeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Infrastructure.Entities.Inventory.Option ToEntity()
        {
            //return null;
            return new Infrastructure.Entities.Inventory.Option
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
    */

    public class OptionModel
    {
        public string Name { get; set; }
        public List<OptionValueModel> OptionValues { get; set; }
    }

    public class OptionValueModel
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
        public string Value { get; set; }

    }

}
