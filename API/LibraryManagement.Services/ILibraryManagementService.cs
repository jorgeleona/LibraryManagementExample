using LibraryManagement.Model;

namespace LibraryManagement.Services;

public interface ILibraryManagementService<T, ADto, UDto> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task<T?> Create(ADto addDto);
    Task<T?> Update(UDto updateDto);
    Task<bool> Delete(int id);
}

