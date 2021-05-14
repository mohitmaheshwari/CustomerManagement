using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementService.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext RepositoryContext { get; set; }

        protected RepositoryBase(AppDbContext dbContext)
        {
            RepositoryContext = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext
                .Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<T> Create(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);

            await RepositoryContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
