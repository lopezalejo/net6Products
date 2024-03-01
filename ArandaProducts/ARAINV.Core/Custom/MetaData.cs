using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Custom
{
    public class MetaData<T>
    {
        public Pagination pagination {get; set;}
        public IEnumerable<T> data { get; set;}

    }
}
