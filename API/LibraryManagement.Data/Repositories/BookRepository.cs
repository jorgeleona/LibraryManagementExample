
using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryManagementContext _context;
    public BookRepository(LibraryManagementContext context)
    {
        _context = context;
    }
    public async Task<Book?> Create(Book newEntity)
    {
        _context.Books.Add(newEntity);
        int changes = await _context.SaveChangesAsync();
        return changes > 0 ? newEntity : null;
    }

    public async Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _context.Books.AsNoTracking().Where(auth => auth.IsActive).ToListAsync();
    }

    public async Task<Book?> GetById(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> Update(Book toUpdate)
    {
        if (!toUpdate.IsValid(out string validMessage)) throw new ArgumentException(validMessage);

        Book? book = await _context.Books.FindAsync(toUpdate.Id);
        if (book != null)
        {
            book.Title = toUpdate.Title;
            book.UpdateLastModified();
        }
        int changes = await _context.SaveChangesAsync();
        return changes > 0 ? book : null;
    }
}

