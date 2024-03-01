using ARAINV.Core.Custom;
using ARAINV.Core.Entities;
using ARAINV.Infrastructure.DTOs.Products;
using System.Linq.Expressions;

namespace ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service
{
    public interface IProductService
    {
        public int RowCount { get; }   
        Task<ProductDTO> FindProductAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDTO>> GetProducts(CancellationToken cancellationToken = default);
        Task<MetaData<ProductDTO>> GetPagedProductAsync(int pageNumber, int pageSize, FilterProductDTO product, string orderBy = null, CancellationToken cancellationToken = default);
        Task<CreateProductDTO> InsertAsync(CreateProductDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateProductDTO> UpdateProduct(UpdateProductDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteProductDTO> DeleteProduct(DeleteProductDTO objDTO, CancellationToken cancellationToken = default);
    }
}
