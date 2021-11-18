using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;

namespace Service.Interfaces
{
    public interface IManufactureService
    {
        ManufactureModel GetManufacture(int id);
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
        List<UserManufactureProductModel> GetEmployeesHistoryOfManufactureDepartment(int manufactureId, int departmentId, int userId);
    }
}
