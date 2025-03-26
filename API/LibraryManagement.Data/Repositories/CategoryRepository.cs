
using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly LibraryManagementContext _context;
    public CategoryRepository(LibraryManagementContext context)
    {
        _context = context;
    }
    public async Task<Category?> Create(Category newEntity)
    {
        _context.Categories.Add(newEntity);
        int changes = await _context.SaveChangesAsync();
        return changes > 0 ? newEntity : null;
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.AsNoTracking().Where(auth => auth.IsActive).ToListAsync();
    }

    public async Task<Category?> GetById(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category?> Update(Category toUpdate)
    {
        if (!toUpdate.IsValid(out string validMessage)) throw new ArgumentException(validMessage);

        Category? category = await _context.Categories.FindAsync(toUpdate.Id);
        if (category != null)
        {
            category.Name = toUpdate.Name;
            category.UpdateLastModified();
        }
        int changes = await _context.SaveChangesAsync();
        return changes > 0 ? category : null;
    }
}

