using LibraryManagement.Data.Repositories;
using LibraryManagement.Model;
using LibraryManagement.Model.DTOs;

namespace LibraryManagement.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<Book?> Create(AddBookDto dto)
    {
        Book toCreate = new Book
        {
            Title = dto.Title,
            PublishedDate = dto.PublishedDate,
            AuthorId  = new Guid("FE289612-4B76-49D5-B454-EBE56F9CB64A"),
            Author = null,
            Categories = new List<Category>(),
            IsActive = true,
        };

        return await _repository.Create(toCreate);
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Book?> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Book?> Update(UpdateBookDto dto)
    {
          Book entity = new Book
        {
            Title = dto.Title,
            PublishedDate = dto.PublishedDate,
            AuthorId  = new Guid("FE289612-4B76-49D5-B454-EBE56F9CB64A"),
            Author = null,
            Categories = new List<Category>(),
            IsActive = true,
        };
        return await _repository.Update(entity);
    }
}

