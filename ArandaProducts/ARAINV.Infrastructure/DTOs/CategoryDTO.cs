using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Infrastructure.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string NameCategory { get; set; } = null!;
        public DateTime Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
