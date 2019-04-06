using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.DbEventArgs;
using Service.Listeners;
using ViewModel.Core.Suppliers;

namespace Service.Core.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public SupplierService(DatabaseContext context, IDatabaseChangeListener listener)
        {
            _context = context;
            _listener = listener;
        }
        public void AddOrUpdateSupplier(SupplierModel supplierModel)
        {
            var now = DateTime.Now;
            var dbEntity = _context.Supplier
                .Include(x => x.BasicInfo)
                .FirstOrDefault(x => x.Id == supplierModel.Id);
            BaseEventArgs<SupplierModel> eventArgs = BaseEventArgs<SupplierModel>.Instance;
            dbEntity = SupplierMapper.MapToEntity(supplierModel, dbEntity);
            if (dbEntity.Id == 0)
            {
                // add
                dbEntity.BasicInfo.CreatedAt = now;
                dbEntity.BasicInfo.UpdatedAt = now;
                _context.Supplier.Add(dbEntity);
                eventArgs.Mode = Utility.UpdateMode.ADD;
            }
            else
            {
                dbEntity.BasicInfo.UpdatedAt = now;
                // update; not needed to assign cause Mapper has already assigned; just set the mode of eventArgs
                eventArgs.Mode = Utility.UpdateMode.EDIT;
            }
            _context.SaveChanges();
            eventArgs.Model = SupplierMapper.MapToSupplierModel(dbEntity);
            _listener.TriggerSupplierUpdateEvent(null, eventArgs);
        }

        public void DeleteSupplier(int supplierId)
        {
            var entity = _context.Supplier.Find(supplierId);
            if(entity != null)
            {
                entity.BasicInfo.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                var args = new BaseEventArgs<SupplierModel>(SupplierMapper.MapToSupplierModel(entity), Utility.UpdateMode.DELETE);
                _listener.TriggerSupplierUpdateEvent(null, args);
            }
        }

        public SupplierModel GetSupplier(int supplierId)
        {
            var supplier = _context.Supplier.Find(supplierId);
            if (supplier == null)
                return null;
            return SupplierMapper.MapToSupplierModel(supplier);
        }

        public List<SupplierModel> GetSupplierList()
        {
            var query = _context.Supplier
                .Include(x => x.BasicInfo)
                .Where(x => x.BasicInfo.DeletedAt == null);
            return SupplierMapper.MapToSupplierModel(query);
        }

    }
}
