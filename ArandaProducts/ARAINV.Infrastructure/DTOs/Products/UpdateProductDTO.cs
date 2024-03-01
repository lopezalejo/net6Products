using ARAINV.Infrastructure.Wrappers;
using MediatR;

namespace ARAINV.Infrastructure.DTOs.Products
{
    public class UpdateProductDTO : IRequest<ApiResponse<UpdateProductDTO>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
