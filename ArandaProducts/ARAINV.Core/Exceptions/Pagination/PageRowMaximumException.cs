using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Exceptions.Pagination
{
    public class PageRowMaximumException : Exception
    {
        public object ValueInfo { get; set; }
        public PageRowMaximumException() : base() { }
        public PageRowMaximumException(object valueInfo) : base($"El valor '{valueInfo}'  es mayor al maximo de registros por página.")
        {
            ValueInfo = valueInfo;
        }
        public PageRowMaximumException(string message) : base(message) { }
        public PageRowMaximumException(string message, Exception innerException) : base(message, innerException) { }
    }
}
