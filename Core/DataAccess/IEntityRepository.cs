using Entities.Concrete.DbEntities.Base;
using System.Linq.Expressions;

namespace Core.DataAccess;

public interface IEntityRepository<T> where T : BaseEntity //TODO bu arkadaşın imza türünü belirtmedin.
{
    T Add(T entity);
    T Update(T entity);
    void Delete(T entity);

    IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);

    T Get(Expression<Func<T, bool>> expression);

    int SaveChanges();

    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);

    Task<T> GetAsync(Expression<Func<T, bool>> expression);

    Task<int> SaveChangesAsync();

    IQueryable<T> Query();
}