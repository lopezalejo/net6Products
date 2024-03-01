using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search {  get; set; }
        public string Fields { get; set; }
        public string OrderBy { get; set; }
        public RequestParameter() { PageNumber = 0; PageSize = 0; Fields = string.Empty; Search = string.Empty; OrderBy = string.Empty; }
        public RequestParameter(int pageNumber, int pageSize, string search, string fields, string orderBy)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 100 ? 100 : pageSize;
            Search = search;
            Fields = fields;
            OrderBy = orderBy;
        }
    }
}
