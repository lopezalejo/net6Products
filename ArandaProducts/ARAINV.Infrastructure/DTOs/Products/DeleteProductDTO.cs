using ARAINV.Infrastructure.Wrappers;
using MediatR;

namespace ARAINV.Infrastructure.DTOs.Products
{
    public class DeleteProductDTO : IRequest<ApiResponse<DeleteProductDTO>>
    {
        public int Id { get; set; }
        public Boolean deleted { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
