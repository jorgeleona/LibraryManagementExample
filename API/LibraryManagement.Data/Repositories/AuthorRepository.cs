
using LibraryManagement.Model;

namespace LibraryManagement.Data.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryManagementContext _context;
    public AuthorRepository(LibraryManagementContext context)
    {
        _context = context;
    }

    public async Task<Author> Create(Author entity)
    {
        _context.Authors.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Author>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Author> Update(Author entity)
    {
        throw new NotImplementedException();
    }
}

