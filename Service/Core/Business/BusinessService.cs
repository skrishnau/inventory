﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Business;
using Infrastructure.Context;
using Infrastructure.Entities.Business;
using Service.DbEventArgs;
using Service.Listeners;
using Service.Listeners.Business;
using ViewModel.Core.Business;
using ViewModel.Core.Common;

namespace Service.Core.Business
{
    public class BusinessService : IBusinessService
    {
       // private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public BusinessService( IDatabaseChangeListener listener)// DatabaseContext context,
        {
            //_context = context;
            _listener = listener;
        }

        public int AddOrUpdateBranch(BranchModel branch)
        {
            using (var _context = new DatabaseContext())
            {

            var dbEntity = _context.Branch.FirstOrDefault(x => x.Id == branch.Id);
            BranchEventArgs args = BranchEventArgs.Instance;
            if (dbEntity == null)
            {
                var entity = _context.Branch.FirstOrDefault(x => x.Name == branch.Name);
                if (entity != null)
                    return 0;
                // branch save
                dbEntity = BranchMapper.MapToEntity(branch);// branch.ToEntity();
                dbEntity.CreatedAt = DateTime.Now;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.Branch.Add(dbEntity);
                args.Mode = Utility.UpdateMode.ADD;
            }
            else
            {
                dbEntity.Name = branch.Name;
                dbEntity.UpdatedAt = DateTime.Now;
                args.Mode = Utility.UpdateMode.EDIT;
            }
            _context.SaveChanges();
            args.BranchModel = BranchMapper.MapToBranchModel(dbEntity);
            _listener.TriggerBranchUpdateEvent(this, args);
            return dbEntity.Id;
            }
        }

        public void AddOrUpdateCounter(CounterModel counter)
        {
            using (var _context = new DatabaseContext())
            {

            var dbEntity = _context.Counter.FirstOrDefault(x => x.Id == counter.Id);
            if (dbEntity == null)
            {
                var counterEntity = counter.ToEntity();
                counterEntity.CreatedAt = DateTime.Now;
                counterEntity.UpdatedAt = DateTime.Now;
                _context.Counter.Add(counterEntity);
            }
            else
            {
                dbEntity.Name = counter.Name;
                dbEntity.BranchId = counter.BranchId;
                dbEntity.OutOfOrder = counter.OutOfOrder;
                dbEntity.UpdatedAt = DateTime.Now;
            }
            _context.SaveChanges();
            }
            //throw new NotImplementedException();
        }

        //public void DeleteBranch(int branchId)
        //{
        //    var dbEntity = _context.Branch.FirstOrDefault(x => x.Id == branchId);
        //    if (dbEntity != null)
        //    {
        //        dbEntity.DeletedAt = DateTime.Now;
        //        _context.SaveChanges();
        //        var args = new BranchEventArgs(BranchMapper.MapToBranchModel(dbEntity), Utility.UpdateMode.DELETE);
        //        _listener.TriggerBranchUpdateEvent(null, args);
        //    }
        //}

        public List<CounterModel> GetCounterList()
        {
            using (var _context = new DatabaseContext())
            {

            var counters = _context.Counter
                   //.Where(x => x.DeletedAt == null)
                   .Select(x => new CounterModel()
                   {
                       Name = x.Name,
                       Id = x.Id,
                       BranchId = x.BranchId,
                       OutOfOrder = x.OutOfOrder,
                       CreatedAt = x.CreatedAt,
                       UpdatedAt = x.UpdatedAt
                   })
                   .ToList();

            return counters;
            }
        }

        public List<BranchModel> GetBranchList()
        {
            using (var _context = new DatabaseContext())
            {

            var branches = _context.Branch
                   //.Where(x => x.DeletedAt == null)
                   .Select(x => new BranchModel()
                   {
                       Name = x.Name,
                       Id = x.Id,
                       CreatedAt = x.CreatedAt,
                       UpdatedAt = x.UpdatedAt
                   })
                   .ToList();

            return branches;
            }
        }

       
    }
}
