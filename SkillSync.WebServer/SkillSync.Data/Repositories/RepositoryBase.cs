using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace SkillSync.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected RepositoryContext context;

        public RepositoryBase(RepositoryContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            var newEntity = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<bool> AnyByCondition(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> SingleByCondition(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
    }
}