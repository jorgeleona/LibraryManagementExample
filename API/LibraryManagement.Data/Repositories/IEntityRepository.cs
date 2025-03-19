
using LibraryManagement.Model;

namespace LibraryManagement.Data.Repositories;

public interface IEntityRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(int id);
}

