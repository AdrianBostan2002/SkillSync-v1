using System.Linq.Expressions;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetById(long id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        public Task<T> SingleByCondition(Expression<Func<T, bool>> expression);
        public Task<bool> AnyByCondition(Expression<Func<T, bool>> expression);
    }
}