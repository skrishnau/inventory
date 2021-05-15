using Infrastructure.Context;
using Infrastructure.Entities.Inventory;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public class UomService : IUomService
    {
        public UomService()
        {

        }

        public decimal ConvertUom(int fromPackageId, int toPackageId, int? productId, decimal multiplier = 1)
        {
            using (var _context = new DatabaseContext())
            {
                return ConvertUom(_context, fromPackageId, toPackageId, productId, multiplier);
            }
        }

        public decimal ConvertUom(DatabaseContext _context, int fromPackageId, int toPackageId, int? productId, decimal multiplier = 1)
        {
            decimal val = 1;
            if (fromPackageId > 0 && toPackageId > 0)
                val = ConvertUom(_context, fromPackageId, toPackageId, productId);
            return val * multiplier;
        }

        private decimal ConvertUom(DatabaseContext _context, int fromPackageId, int toPackageId, int? productId)
        {
            var isProductSpecific = ((productId ?? 0) > 0);
            var from = _context.Package.FirstOrDefault(x => x.Id == fromPackageId);
            var to = _context.Package.FirstOrDefault(x => x.Id == toPackageId);
            List<Uom> allRelated;
            if (isProductSpecific)
                allRelated = _context.Uom.Where(x => x.ProductId == productId).ToList();
            else
                allRelated = _context.Uom.Where(x => x.ProductId == null).ToList();
            //var allRelated = uoms.Where(x => x.PackageId == from.Id || x.RelatedPackageId == from.Id || x.PackageId == to.Id || x.RelatedPackageId == to.Id).ToList();
            var path = GetUomPath(_context, from, to, allRelated, null, new List<int>());
            if (path.IsRightPath)
            {
                var value = GetUomValue(path, fromPackageId);
                return value;
            }
            else if (isProductSpecific)
            {
                // try with both product and global once again
                allRelated = _context.Uom.Where(x => x.ProductId == productId || x.ProductId == null).ToList();
                var pathGlobal = GetUomPath(_context, from, to, allRelated, null, new List<int>());
                if (pathGlobal.IsRightPath)
                {
                    var value = GetUomValue(pathGlobal, fromPackageId);
                    return value;
                }
            }
            return 0;
        }

        private decimal GetUomValue(UomPath path, int fromPackageId)
        {
            var isFromPackageEqualToSource = path.Uom.PackageId == fromPackageId;
            var convertRatio = isFromPackageEqualToSource ? path.Uom.Quantity : 1 / path.Uom.Quantity;
            if (path.Paths.Count == 0)
            {
                return convertRatio;
            }
            var from = isFromPackageEqualToSource ? path.Uom.RelatedPackageId : path.Uom.PackageId;
            var p = path.Paths.FirstOrDefault();
            var quantity = GetUomValue(p, from);
            convertRatio *= quantity;
            return convertRatio;
        }

        private UomPath GetUomPath(DatabaseContext _context, Package from, Package to, List<Uom> allRelated, int? currentUomId, List<int> allEarlierPackages)
        {
            var uomPath = new UomPath();
            if (from.Id == to.Id)
            {
                return new UomPath { IsRightPath = true, Uom = new Uom() { Package = from, RelatedPackage = to, Quantity = 1 } };
            }
            var copy = MakeCopy(allEarlierPackages);
            copy.Add(from.Id);
            var source = allRelated.Where(x => x.Use && (x.PackageId == from.Id || x.RelatedPackageId == from.Id) && x.Id != currentUomId).ToList();
            foreach (var m in source)
            {
                // get the other package 
                var currentPackageToCheck = m.PackageId != from.Id ? m.Package : m.RelatedPackage;
                if (!copy.Contains(currentPackageToCheck.Id))
                {
                    var isRight = currentPackageToCheck.Id == to.Id;
                    if (isRight)
                    {
                        return new UomPath { Uom = m, IsRightPath = isRight };
                    }
                    var uomp = GetUomPath(_context, currentPackageToCheck, to, allRelated, m.Id, copy);
                    if (uomp != null && uomp.IsRightPath)
                    {
                        uomPath.IsRightPath = uomp.IsRightPath;//uomp.Paths.Any(x => x.IsRightPath);
                        uomPath.Uom = m;
                        uomPath.Paths.Add(uomp);
                    }
                }
            }
            return uomPath;
        }
        private List<int> MakeCopy(List<int> allEarlierpackages)
        {
            return allEarlierpackages.ToArray().ToList();
        }
    }
    public class UomPath
    {
        public UomPath()
        {
            //Uoms = new List<Uom>();
            Paths = new List<UomPath>();
        }
        public Uom Uom { get; set; }
        public bool IsRightPath { get; set; }

        public List<UomPath> Paths { get; set; }
    }
}
