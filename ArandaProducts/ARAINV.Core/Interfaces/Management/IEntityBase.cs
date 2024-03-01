using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Interfaces.Management
{
    public interface IEntityBase<TKey> : IAddEntity<TKey>, IUpdateEntity<TKey>, IDeleteEntity<TKey> { }
}
