using LibraryManagement.Model;

namespace LibraryManagement.Services;

public interface ILibraryManagementService<T, ADto> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(ADto addDto);
    Task<T> Update(T entity);
    Task<bool> Delete(int id);
}

