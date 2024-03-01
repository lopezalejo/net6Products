using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Custom
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage  => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NexPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?) null;

        public PagedList(IEnumerable<T> data, int pageNumber, int pageSize, int totalRows, string? fields = null, string? orderBy = null, string? search = null)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = totalRows;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            AddRange(data);
        }
    }
}
