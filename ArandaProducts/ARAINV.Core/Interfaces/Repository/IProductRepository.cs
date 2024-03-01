using ARAINV.Core.Entities;
using ARAINV.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ARAINV.Core.Interfaces.Repository
{
    public interface IProductRepository<TContext> : IBaseRepository<Product, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default, string orderBy = null);
        Task<Product> GetProductAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> FilterProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null);
        Task<IEnumerable<Product>> GetPagedProductAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string orderBy = null);
        Task<Product> SingleProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddProductAsync(Product product, CancellationToken cancellationToken = default);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
