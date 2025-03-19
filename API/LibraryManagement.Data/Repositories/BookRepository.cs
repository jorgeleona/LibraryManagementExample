
using LibraryManagement.Model;

namespace LibraryManagement.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryManagementContext _context;
    public BookRepository(LibraryManagementContext context)
    {
        _context = context;
    }
    public Task<Book> Create(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> Update(Book entity)
    {
        throw new NotImplementedException();
    }
}

