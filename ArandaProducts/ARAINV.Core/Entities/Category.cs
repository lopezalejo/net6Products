using ARAINV.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace ARAINV.Core.Entities
{
    public partial class Category : EntityBase<int>
    {
        public Category()
        {
            TbProducts = new HashSet<Product>();
        }

        public string NameCategory { get; set; } = null;

        public virtual ICollection<Product>? TbProducts { get; set; }
        public virtual User? UserCreate { get; set; } = null!;
        public virtual User? UserModify { get; set; } = null!;
    }
}
