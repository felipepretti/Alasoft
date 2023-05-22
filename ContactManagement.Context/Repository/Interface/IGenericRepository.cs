using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Context.Repository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        void AddOrUpdate(TEntity entity);
        void AddOrUpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll();
        Task SaveChangesAsync();
    }
}
