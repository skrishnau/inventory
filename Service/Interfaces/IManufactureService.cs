using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Inventory;

namespace Service.Interfaces
{
    public interface IManufactureService
    {
        ManufactureModel GetManufacture(int id);
        ManufactureModel GetManufactureOnly(int id);
        ResponseModel<ManufactureModel> SaveManufacture(ManufactureModel model);
        int GetLastLotNo();
        int GetAllManufacturesCount(int categoryId, string searchText);
        Task<ViewListModel<ManufactureModel>> GetAllManufactures(int categoryId, string searchText, int pageSize, int offset);
        ResponseModel<bool> DeleteManufacture(int id);
        List<ManufactureDepartmentModel> GetDepartmentListForManufacture();
        DepartmentModel GetDepartment(int departmentId);
        ResponseModel<DepartmentModel> SaveDepartment(DepartmentModel model);
        ResponseModel<bool> SetManufactureComplete(int id);
        ResponseModel<bool> SetManufactureCancel(int id);
        ResponseModel<bool> SetManufactureStart(int id);
        List<ManufactureDepartmentUserModel> GetEmployeesOfManufactureDepartment(int manufactureId, int depId);
        ManufactureDepartmentUserModel GetManufactureDepartmentUser(int manufactureId, int departmentId, int userId);
        ResponseModel<UserManufactureModel> AddUserManufacture(UserManufactureModel userManufactureModel);
        List<UserManufactureModel> GetEmployeesHistoryOfManufactureDepartment(int manufactureId, int departmentId, int userId);

        int GetAllDepartmentsCount(string searchText);
        Task<ViewListModel<DepartmentModel>> GetAllDepartments(string searchText, int pageSize, int offset);
        List<DepartmentUserModel> GetEmployeesOfDepartment(int departmentId);
        ResponseModel<bool> DeleteDepartment(int departmentId);
        List<ManufactureDepartmentProductModel> GetManufactureDepartmentInProducts(int manufactureId, int departmentId, bool inOut);
        List<InventoryUnitModel> GetManufactureDepartmentProductsInventoryUnit(int manufactureId, int departmentId);
    }
}
