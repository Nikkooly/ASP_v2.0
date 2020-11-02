using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentsService.Models.Students
{
    public static class StudentsFilterHelper
    {
        public static IQueryable<Database.Models.Students> Where(this IQueryable<Database.Models.Students> query, StudentsFilter filter)
        {
            if (filter.MaxId.HasValue)
                query = query.Where(x => x.Id < filter.MaxId.Value);
            if (filter.MinId.HasValue)
                query = query.Where(x => x.Id > filter.MinId.Value);

            if(filter.GlobalLike != null)
                query = query.Where(x => (x.Id.ToString() + x.Name + x.Phone).Contains(filter.GlobalLike));
            if (filter.Like != null)
                query = query.Where(x => x.Name.Contains(filter.Like));
            return query;
        }

        public static IQueryable<Database.Models.Students> Sort(this IQueryable<Database.Models.Students> query, StudentsFilter filter)
        {
            return filter.SortByName.HasValue ? query.OrderBy(x => x.Name) : query.OrderBy(x => x.Id);
        }

        public static IEnumerable<Database.Models.Students> Skip(this IEnumerable<Database.Models.Students> query, StudentsFilter filter)
        {
            if (filter.Offset.HasValue)
                query = query.Skip(filter.Offset.Value);
            if (filter.Limit.HasValue)
                query = query.Take(filter.Limit.Value);
            return query;
        }
    }
}
