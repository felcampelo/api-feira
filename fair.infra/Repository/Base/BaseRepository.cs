using fair.domain.Entities.Base;
using fair.domain.RepositoryInterfaces;
using fair.infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace fair.infra.Repository.Base
{
    public class BaseRepository<T, KeyType> : IBaseRepository<T, KeyType> where T : class, IBaseEntity<KeyType>
    {
        protected readonly FairContext context;

        public BaseRepository(FairContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> where)
        {
            var query = context.Set<T>()
                .Where(where)
                .AsNoTracking();

            return query;
        }

        public virtual async Task<T?> GetSingleById(KeyType id)
        {
            return await context.Set<T>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual async Task<T> Insert(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task DeleteById(KeyType id)
        {
            try
            {
                var entity = await this.GetSingleById(id);
                await this.Delete(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task Delete(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
