using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerManagementService.Data.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}