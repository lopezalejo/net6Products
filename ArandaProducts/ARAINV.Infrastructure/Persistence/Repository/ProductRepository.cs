using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using ARAINV.Core.Data;
using ARAINV.Core.Interfaces.Repository;
using ARAINV.Infrastructure.Persistence.Repository.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ARAINV.Infrastructure.Persistence.Repository
{
    public class ProductRepository : BaseRepository<Product, int, ArandaDbContext>, IProductRepository<ArandaDbContext>
    {
        public ProductRepository(IDbFactory<ArandaDbContext> dbFactory) : base(dbFactory) { }

        public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await GetAllAsync(cancellationToken, orderBy);
        }
        public async Task<Product> GetProductAsync(int id, CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Product>> FilterProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await FilterAsync(predicate, cancellationToken, orderBy);
        }

        public async Task<Product> SingleProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await FilterSingleAsync(predicate, cancellationToken);
        }

        public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            await AddAsync(product, cancellationToken);
        }
        public void UpdateProduct(Product product)
        {
            UpdateProduct(product);
        }
        public void DeleteProduct(Product product)
        {
            DeleteProduct(product);
        }

        public async Task<IEnumerable<Product>> GetPagedProductAsync(int pageNumber, int pageSize, Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, orderBy);
        }

        public async Task<IEnumerable<Product>> GetPagedProductAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, string orderBy = null)
        {
            return await GetPagedAsync(pageNumber, pageSize, cancellationToken, orderBy);
        }
    }
}
