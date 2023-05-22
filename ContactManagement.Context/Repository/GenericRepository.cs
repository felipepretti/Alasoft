using ContactManagement.Context.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Context.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        internal MariaDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(MariaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void AddOrUpdate(TEntity entity)
        {
            _ = !_dbSet.Any(e => e == entity) ? _dbSet.Add(entity) : _dbSet.Update(entity);
        }

        public virtual void AddOrUpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _ = !_dbSet.Any(e => e == entity) ? _dbSet.Add(entity) : _dbSet.Update(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        { 
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }            
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
