using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Exceptions.Pagination
{
    public class PageRowMinimumException : Exception
    {
        public object ValueInfo { get; set; }
        public PageRowMinimumException() : base() { }
        public PageRowMinimumException(object valueInfo) : base($"El valor '{valueInfo}' es menor al mínimo de registros por página.")
        {
            ValueInfo = valueInfo;
        }
        public PageRowMinimumException(string message) : base(message) { }
        public PageRowMinimumException(string message, Exception innerException) : base(message, innerException) { }
    }
}
