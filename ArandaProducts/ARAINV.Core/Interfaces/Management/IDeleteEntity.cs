using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Interfaces.Management
{
    public interface IDeleteEntity<TKey> : IAddEntity<TKey>
    {
        public Boolean? deleted { get; set; }
    }
}
