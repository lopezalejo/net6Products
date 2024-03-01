using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Core.Exceptions.Core.Persistence
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; set; }
        public object Id { get; set; }

        public EntityNotFoundException() : base() { }
        public EntityNotFoundException(Type entityType) : this(entityType, null, null) { }
        public EntityNotFoundException(Type entityType, object id) : this(entityType, id, null) { }

        public EntityNotFoundException(Type entityType, object id, Exception innerException) : base(
            id == null ? $"No se encontró una entidad que tome este id. Entidad: {entityType.FullName}" :
                         $"No se encontró una entidad que tome este id. Entidad: {entityType.FullName}, id: {id}", innerException
            ) 
        {
            EntityType = entityType;
            Id = id;
        }

        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
