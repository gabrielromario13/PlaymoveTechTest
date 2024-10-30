using PlaymoveTechTest.Domain.Model;
using System.Linq.Expressions;

namespace PlaymoveTechTest.Domain.Interfaces;

public interface IRepositoryAsync<T> where T : BaseEntity
{
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
    Task<T> GetById(int id);
    Task<T> GetSingle(Expression<Func<T, bool>> predicate = default!);
    Task<IEnumerable<T>> Get();
}