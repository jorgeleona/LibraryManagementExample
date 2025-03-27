using LibraryManagement.Model;
using LibraryManagement.Model.DTOs;

namespace LibraryManagement.Services;

public interface IBookService : ILibraryManagementService<Book, AddBookDto, UpdateBookDto> { }

