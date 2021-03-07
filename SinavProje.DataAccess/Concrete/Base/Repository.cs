using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinavProje.DataAccess.Abstract.Base;
using SinavProje.Entities.Abstract.Entities.Base;

namespace SinavProje.DataAccess.Concrete.Base
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task<int> Add(TEntity entity)
        {
            TContext context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(TEntity entity)
        {
            TContext context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            TContext context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            TContext context = new TContext();
            return filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();

        }

        public async Task Update(TEntity entity)
        {
            TContext context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
