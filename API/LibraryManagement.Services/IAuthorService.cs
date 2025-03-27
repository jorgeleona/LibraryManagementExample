using LibraryManagement.Model;
using LibraryManagement.Model.DTOs;

namespace LibraryManagement.Services;

public interface IAuthorService : ILibraryManagementService<Author, AddAuthorDto, UpdateAuthorDto> { }

