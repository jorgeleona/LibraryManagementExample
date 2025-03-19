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

    public Task<Book> Create(AddBookDto dto)
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

