using System.Collections.Generic;
using Infrastructure.Context;
using ViewModel.Core.Business;

namespace DTO.Core.Business
{
    public static class CounterMapper
    {
        internal static ICollection<Counter> MapToEntity(ICollection<CounterModel> counters)
        {
            var list = new List<Counter>();
            foreach(var counter in counters)
            {
                list.Add(MapToEntity(counter));
            }
            return list;
        }

        internal static Counter MapToEntity(CounterModel counter)
        {
            return new Counter()
            {
                CreatedAt = counter.CreatedAt,
                BranchId = counter.BranchId,
                Name = counter.Name,
                OutOfOrder = counter.OutOfOrder,
                UpdatedAt = counter.UpdatedAt,
                Id = counter.Id,
            };
        }
    }
}
