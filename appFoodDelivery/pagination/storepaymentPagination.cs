using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.pagination
{
    public class storepaymentPagination<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public storepaymentPagination(List<T> items, int count, int pageindex, int pagesize)
        {
            PageIndex = pageindex;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            this.AddRange(items);
        }
        public bool IsPreviousAvailable => PageIndex > 1;
        public bool IsNextAvailable => PageIndex < TotalPages;

        public static storepaymentPagination<T> Create(IList<T> source, int pageindex, int pagesize)
        {
            var count = source.Count();
            var items = source.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return new storepaymentPagination<T>(items, count, pageindex, pagesize);
        }
    }
}
