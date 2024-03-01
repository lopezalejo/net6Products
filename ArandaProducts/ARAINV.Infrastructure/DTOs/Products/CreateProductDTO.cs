using ARAINV.Infrastructure.Wrappers;
using MediatR;

namespace ARAINV.Infrastructure.DTOs.Products
{
    public class CreateProductDTO : IRequest<ApiResponse<CreateProductDTO>>
    {
        public string NameProduct { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public DateTime Created { get; set; }
        public int? CreatedBy { get; set; }
    }
}
