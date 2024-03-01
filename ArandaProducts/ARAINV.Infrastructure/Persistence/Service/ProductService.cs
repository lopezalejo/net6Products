using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service;
using ARAINV.Core.Data;
using ARAINV.Infrastructure.DTOs.Products;
using ARAINV.Core.Interfaces.Repository;
using ARAINV.Infrastructure.Persistence.Service.Base;
using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ARAINV.Core.Exceptions.Pagination;
using ARAINV.Core.Custom;
using LinqKit;

namespace ARAINV.Infrastructure.Persistence.Service
{
    public class ProductService : CRUDService<ProductDTO, CreateProductDTO, UpdateProductDTO, DeleteProductDTO, int,
                                              Product, IProductRepository<ArandaDbContext>, ArandaDbContext>, IProductService
    {
        public int RowCount { get; }
        public ProductService(IMapper mapper, IUnitOfWork<ArandaDbContext> unitOfWork, IProductRepository<ArandaDbContext> productRepository) :
            base(productRepository, unitOfWork, mapper)
        { }

        public async Task<IEnumerable<ProductDTO>> GetProducts(CancellationToken cancellationToken = default)
        {
            var products = await GetAll(cancellationToken);
            return products.Where(p => p.deleted == false);
        }

        public async Task<ProductDTO> FindProductAsync(int id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<ProductDTO>> FilterProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await FilterAsync(predicate, cancellationToken);
        }

        public async Task<CreateProductDTO> InsertProductAsync(CreateProductDTO objDTO, CancellationToken cancellationToken = default)
        {
            return await InsertAsync(objDTO, cancellationToken);
        }
        public async Task<UpdateProductDTO> UpdateProduct(UpdateProductDTO objDTO, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(objDTO, cancellationToken);
        }
        public async Task<DeleteProductDTO> DeleteProduct(DeleteProductDTO objDTO, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync(objDTO, cancellationToken);
        }

        public async Task<MetaData<ProductDTO>> GetPagedProductAsync(int pageNumber, int pageSize, FilterProductDTO product, string orderBy = null, CancellationToken cancellationToken = default)
        {
            if (pageSize < 1)
                throw new PageRowMinimumException(pageSize);

            if (pageSize > 500)
                throw new PageRowMaximumException(pageSize);

            var predicate = PredicateBuilder.New<Product>();

            if (product != null)
            {
                if (product.Id != null)
                {
                    predicate.And(p => p.Id == product.Id);
                }

                if (product.NameProduct != null)
                {
                    predicate.And(p => p.NameProduct.Contains(product.NameProduct));
                }

                if (product.Description != null)
                {
                    predicate.And(p => p.Description.Contains(product.Description));
                }

                if (product.Deleted != null)
                {
                    predicate.And(p => p.deleted == product.Deleted);
                }

            }

            int numRegisters = GetCount(predicate);
            int totalPages = ((int)Math.Ceiling(numRegisters / (double)pageSize));

            if (pageNumber < 1 || pageNumber > totalPages)
            {
                throw new PageRowIndexNotFound(pageNumber);
            }

            Pagination pag = new Pagination(pageNumber, totalPages, pageSize, numRegisters);            
            var products = await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, orderBy);

            

            MetaData<ProductDTO> result = new MetaData<ProductDTO>();
            result.data = products;
            result.pagination = pag;

            return result;
        }
    }
}
