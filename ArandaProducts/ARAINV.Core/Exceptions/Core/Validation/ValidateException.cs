using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Exceptions.Core.Validation
{
    public class ValidateException : Exception
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
        public ValidateException(IReadOnlyDictionary<string, string[]> errorsDictionary) :
            base("Han ocurrido uno o mas errores de validación")
        {
            ErrorsDictionary = errorsDictionary;
        }
    }
}
