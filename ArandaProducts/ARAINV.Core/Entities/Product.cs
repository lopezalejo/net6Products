using ARAINV.Core.Entities.Base;

namespace ARAINV.Core.Entities
{
    public partial class Product : EntityBase<int>
    {
        //public Product() 
        //{
        //    OrderDetails = new HashSet<OrderDetail>();
        //}

        public string NameProduct { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public virtual Category? Category { get; set; } = null!;
        public virtual User? UserCreate { get; set; } = null!;
        public virtual User? UserModify { get; set; } = null!;
    }
}
