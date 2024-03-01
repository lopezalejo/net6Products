using ARAINV.Infrastructure.Wrappers;
using MediatR;

namespace ARAINV.Infrastructure.DTOs.Products
{
    public class ProductDTO : IRequest<ApiResponse<ProductDTO>>
    {
        public int Id { get; set; }
        public string NameProduct { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public DateTime Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
        public Boolean deleted { get; set; }
    }
}
