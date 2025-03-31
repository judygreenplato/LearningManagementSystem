using Domain.Contracts;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Infrastructure.Repositories;
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected LmsContext Context { get; }
    protected DbSet<T> DbSet { get; }

    public RepositoryBase(LmsContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public IQueryable<T> FindAll(bool trackChanges = false) =>
                        trackChanges ? DbSet :
                                       DbSet.AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
                         trackChanges ? DbSet.Where(expression) :
                                        DbSet.Where(expression).AsNoTracking();

    public void Create(T entity) => DbSet.Add(entity);
    public void Delete(T entity) => DbSet.Remove(entity);
    public void Update(T entity) => DbSet.Update(entity);

}
