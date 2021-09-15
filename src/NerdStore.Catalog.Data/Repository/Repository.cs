using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot, new()
    {
        protected readonly CatalogContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(CatalogContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<TEntity>> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public virtual async Task<TEntity> GetByIdTracked(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        //public Task<int> SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
