using InstagramClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetByIdAsync(string id, bool tracking = true);
        Task<bool> AddAsync(TEntity model);
        Task<bool> AddRangeAsync(List<TEntity> datas);
        bool Remove(TEntity model);
        bool RemoveRange(List<TEntity> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(TEntity model);
        Task<int> SaveAsync();
    }
}
