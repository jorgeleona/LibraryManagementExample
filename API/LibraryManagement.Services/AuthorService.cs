using LibraryManagement.Model;
using LibraryManagement.Data.Repositories;
using LibraryManagement.Model.DTOs;

namespace LibraryManagement.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Author?> Create(AddAuthorDto dto)
    {
        Author toCreate = new Author
        {
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth,
            IsActive = true,
        };

        return await _repository.Create(toCreate);
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Author?> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Author?> Update(UpdateAuthorDto dto)
    {
        Author toCreate = new Author
        {
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth,
            IsActive = true,
        };

        return await _repository.Update(toCreate);
    }
}

