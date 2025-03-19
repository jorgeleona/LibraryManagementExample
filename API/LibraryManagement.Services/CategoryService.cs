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

    public Task<Category> Create(AddCategoryDto dto)
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

