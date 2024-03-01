using ARAINV.Core.Exceptions.Core.Persistence;
using ARAINV.Core.Interfaces.Base;
using ARAINV.Core.Interfaces.Management;
using ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ARAINV.Infrastructure.Persistence.Service.Base
{
    public class CRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext> : ICRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        internal readonly IMapper _mapper;
        internal readonly TRepoAll _repoAll;
        internal readonly IUnitOfWork<TContext> _unitOfWork;

        protected IMapper Mapper => _mapper;
        protected TRepoAll Repository => _repoAll;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public CRUDService(TRepoAll repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
        {
            _repoAll = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repoAll.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity getEntity = await _repoAll.GetByIdAsync(id, cancellationToken);

            if (getEntity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }
            return _mapper.Map<TGetDto>(getEntity);
        }

        public async Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repoAll.FilterAsync(predicate, cancellationToken);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<TAddDto> InsertAsync(TAddDto objDTO, CancellationToken cancellationToken = default)
        {
            TEntity addEntity = Mapper.Map<TEntity>(objDTO);
            addEntity.Created = DateTime.UtcNow;
            await _repoAll.AddAsync(addEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Mapper.Map<TAddDto>(addEntity);
        }
        public async Task<TUpdDto> UpdateAsync(TUpdDto objDTO, CancellationToken cancellationToken = default)
        {
            TEntity updateEntity = await _repoAll.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

            Mapper.Map(objDTO, updateEntity);

            updateEntity.LastModified = DateTime.UtcNow;

            _repoAll.Update(updateEntity);

            await _unitOfWork.CommitAsync(cancellationToken);
            return Mapper.Map<TUpdDto>(updateEntity);
        }
        public async Task<TDelDto> DeleteAsync(TDelDto objDTO, CancellationToken cancellationToken = default)
        {
            TEntity deleteEntity = await _repoAll.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

            Mapper.Map(objDTO, deleteEntity);
            deleteEntity.deleted = true;
            deleteEntity.LastModified = DateTime.UtcNow;

            _repoAll.Update(deleteEntity);

            await _unitOfWork.CommitAsync(cancellationToken);
            return Mapper.Map<TDelDto>(deleteEntity);

        }

        public int GetCount() { return _repoAll.GetCount(); }

        public int GetCount(Expression<Func<TEntity, bool>> predicate) { return _repoAll.GetCount(predicate); }

        public async Task<IEnumerable<TGetDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string orderBy = null)
        {
            IEnumerable<TEntity> list = await _repoAll.GetPagedAsync(pageNumber, pageSize, cancellationToken, orderBy);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<IEnumerable<TGetDto>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string orderBy = null)
        {
            IEnumerable<TEntity> list = await _repoAll.GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, orderBy);

            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }
    }
}

