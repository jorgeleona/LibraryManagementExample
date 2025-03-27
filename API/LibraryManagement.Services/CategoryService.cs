using LibraryManagement.Model;
using LibraryManagement.Data.Repositories;
using LibraryManagement.Model.DTOs;

namespace LibraryManagement.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category?> Create(AddCategoryDto dto)
    {
        Category toCreate = new Category()
        {
            Name = dto.Name,
            Books = new List<Book>(),
            IsActive = true,
        };

        return await _repository.Create(toCreate);

        }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async  Task<IEnumerable<Category>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Category?> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Category?> Update(UpdateCategoryDto dto)
    {
         Category entity = new Category()
        {
            Name = dto.Name,
            Books = new List<Book>(),
            IsActive = true,
        };
        return await _repository.Update(entity);
    }
}

