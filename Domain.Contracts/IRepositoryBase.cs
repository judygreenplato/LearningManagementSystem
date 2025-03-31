using System.Linq.Expressions;

namespace Domain.Contracts;

//Use if you want
public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges = false);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}

