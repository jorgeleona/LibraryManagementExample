
namespace LibraryManagement.Model.DTOs;

public class AddAuthorDto : IAddDto
{
    public required string Name { get; set; }

    public required DateTime DateOfBirth { get; set; }
}
