using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Enums;

namespace DTO.Core
{
    public class AssignReleaseViewModel
    {
        public int ManufactureId { get; set; }
        public TransferTypeEnum TransferType { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }

        public string FromName { get; set; }
        public string ToName { get; set; }

        public bool FromIsVendor { get; set; }
        public bool ToIsVendor { get; set; }

        public string AssignReleaseText { get; set; }

        public List<InventoryUnitModel> inventoryUnitList { get; set; }

        public FromToType FromType
        {
            get
            {
                switch (TransferType)
                {
                    case TransferTypeEnum.WarehouseToWarehouse:
                    case TransferTypeEnum.WarehouseToDepartment:
                        return FromToType.Warehouse;
                    case TransferTypeEnum.DepartmentToWarehouse:
                    case TransferTypeEnum.DepartmentToDepartment:
                    case TransferTypeEnum.DepartmentToUser:
                        return FromToType.Department;
                    case TransferTypeEnum.UserToDepartment:
                        return FromToType.Employee;
                }
                return FromToType.Employee;
            }
        }

        public FromToType ToType
        {
            get
            {
                switch (TransferType)
                {
                    case TransferTypeEnum.WarehouseToWarehouse:
                    case TransferTypeEnum.DepartmentToWarehouse:
                        return FromToType.Warehouse;
                    case TransferTypeEnum.WarehouseToDepartment:
                    case TransferTypeEnum.DepartmentToDepartment:
                    case TransferTypeEnum.UserToDepartment:
                        return FromToType.Department;
                    case TransferTypeEnum.DepartmentToUser:
                        return FromToType.Employee;
                }
                return FromToType.Employee;
            }
        }
    }
}
