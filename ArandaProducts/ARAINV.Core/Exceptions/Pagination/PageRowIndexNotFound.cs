using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Exceptions.Pagination
{
    public class PageRowIndexNotFound : Exception
    {
        public object ValueInfo { get; set; }
        public PageRowIndexNotFound() : base() { }
        public PageRowIndexNotFound(object valueInfo) : base($"El número de página '{valueInfo}' no existe en la colección de páginas")
        {
            ValueInfo = valueInfo;
        }
        public PageRowIndexNotFound(string message) : base(message) { }
        public PageRowIndexNotFound(string message, Exception innerException) : base(message, innerException) { }
    }
}
