using ARAINV.Core.Entities;
using ARAINV.Core.Exceptions.Core.Persistence;
using ARAINV.Core.Interfaces.Base;
using ARAINV.Core.Interfaces.Management;
using ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ARAINV.Infrastructure.Persistence.Service.Base
{
    public class RService<TGetDto, TKey, TEntity, TRepoRead, TContext> : IReadbleService<TGetDto, TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        internal readonly IMapper _mapper;
        internal readonly TRepoRead _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;

        protected IMapper Mapper => _mapper;
        protected TRepoRead Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public RService(TRepoRead repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity getEntity = await _repository.GetByIdAsync(id, cancellationToken);

            if (getEntity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }
            return _mapper.Map<TGetDto>(getEntity);
        }
        public async Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken, orderBy);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<IEnumerable<TGetDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, string orderBy = null)
        {
            IEnumerable<TEntity> list = await _repository.GetPagedAsync(pageNumber, pageSize, cancellationToken, orderBy);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<IEnumerable<TGetDto>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            IEnumerable<TEntity> list = await _repository.GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, orderBy);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }
    }
}
