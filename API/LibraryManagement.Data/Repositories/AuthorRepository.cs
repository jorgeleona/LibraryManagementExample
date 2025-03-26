
using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryManagementContext _context;
    public AuthorRepository(LibraryManagementContext context)
    {
        _context = context;
    }

    public async Task<Author?> Create(Author newEntity)
    {
        _context.Authors.Add(newEntity);
        int changes = await _context.SaveChangesAsync();
        return changes > 0 ? newEntity : null;
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _context.Authors.AsNoTracking().Where(auth => auth.IsActive).ToListAsync();
    }

    public async Task<Author?> GetById(Guid authorId)
    {
        return await _context.Authors.FindAsync(authorId);
    }

    public async Task<Author?> Update(Author toUpdate)
    {
        if (!toUpdate.IsValid(out string validMessage)) throw new ArgumentException(validMessage);

        Author? author = await _context.Authors.FindAsync(toUpdate.Id);
        if (author != null)
        {
            author.Name = toUpdate.Name;
            author.DateOfBirth = toUpdate.DateOfBirth;
            author.UpdateLastModified();
        }
        int changes = await _context.SaveChangesAsync();
        return changes > 0 ? author : null;

    }

}

