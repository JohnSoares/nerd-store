using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task<TEntity> GetByIdTracked(Guid id);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(Guid id);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        //Task<int> SaveChanges();
    }
}
