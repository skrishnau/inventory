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
        bool SaveManufacture(ManufactureModel model);
        int GetLastLotNo();
        int GetAllManufacturesCount(int categoryId, string searchText);
        Task<ViewListModel<ManufactureModel>> GetAllManufactures(int categoryId, string searchText, int pageSize, int offset);
        ResponseModel<bool> DeleteManufacture(int id);
    }
}
