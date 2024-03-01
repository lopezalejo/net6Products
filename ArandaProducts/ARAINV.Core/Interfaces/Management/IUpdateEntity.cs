using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Interfaces.Management
{
    public interface IUpdateEntity<TKey> : IAddEntity<TKey>
    {
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
