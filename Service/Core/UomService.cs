using Infrastructure.Context;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public decimal ConvertUom(DatabaseContext _context, int fromPackageId, int toPackageId, int? productId, decimal multiplier = 1, List<Uom> includeThisList = null)
        {
            decimal val = 1;
            if (fromPackageId > 0 && toPackageId > 0)
                val = GetConversion(_context, fromPackageId, toPackageId, productId, includeThisList);
            return val * multiplier;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="fromPackageId"></param>
        /// <param name="toPackageId"></param>
        /// <param name="productId"></param>
        /// <param name="includeThisList">Extra list to include in the checking for uom mapping in product edit</param>
        /// <returns></returns>
        private decimal GetConversion(DatabaseContext _context, int fromPackageId, int toPackageId, int? productId, List<Uom> includeThisList)
        {
            
            var isProductSpecific = ((productId ?? 0) > 0);
            var from = _context.Packages.FirstOrDefault(x => x.Id == fromPackageId);
            var to = _context.Packages.FirstOrDefault(x => x.Id == toPackageId);
            List<Uom> allRelated;

            // for includeList
            if (includeThisList != null && includeThisList.Count > 0)
            {
                var includeListPath = GetUomPath(_context, from, to, includeThisList, null, new List<int>());
                if (includeListPath.IsRightPath)
                {
                    var value = GetUomValue(includeListPath, fromPackageId);
                    return value;
                }
            }
            // general
            if (isProductSpecific)
                allRelated = _context.Uoms.Where(x => x.ProductId == productId).ToList();
            else
                allRelated = _context.Uoms.Where(x => x.ProductId == null).ToList();
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
                allRelated = _context.Uoms.Where(x => x.ProductId == productId || x.ProductId == null).ToList();
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
                return new UomPath { IsRightPath = true, Uom = new Uom() { Package = from, Package1 = to, Quantity = 1 } };
            }
            var copy = MakeCopy(allEarlierPackages);
            copy.Add(from.Id);
            var source = allRelated.Where(x => x.Use && (x.PackageId == from.Id || x.RelatedPackageId == from.Id) && x.Id != currentUomId).ToList();
            foreach (var m in source)
            {
                // get the other package 
                var currentPackageToCheck = m.PackageId != from.Id ? m.Package : m.Package1;
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
