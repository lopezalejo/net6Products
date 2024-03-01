using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Custom
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int? NexPageNumber { get; set; }
        public int? PreviousPageNumber { get; set; }

        public Pagination(int currentPage, int totalPages, int pageSize, int totalCount) 
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
            HasPreviousPage = CurrentPage > 1;
            HasNextPage = CurrentPage < TotalPages;
            NexPageNumber = HasNextPage ? CurrentPage + 1 : (int?)null;
            PreviousPageNumber = HasPreviousPage ? CurrentPage - 1 : (int?)null;
    }
    }
}
