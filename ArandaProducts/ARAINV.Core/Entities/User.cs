using ARAINV.Core.Entities.Base;

namespace ARAINV.Core.Entities
{
    public class User : EntityBase<int>
    {
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public virtual ICollection<Product>? ProductsCre { get; set; }
        public virtual ICollection<Product>? ProductsMod { get; set; }
        public virtual ICollection<Category>? CategoriesCre { get; set; }
        public virtual ICollection<Category>? CategoriesMod { get; set; }

    }
}
