
using LibraryManagement.Model;

namespace LibraryManagement.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly LibraryManagementContext _context;
    public CategoryRepository(LibraryManagementContext context)
    {
        _context = context;
    }
    public Task<Category> Create(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> Update(Category entity)
    {
        throw new NotImplementedException();
    }
}

