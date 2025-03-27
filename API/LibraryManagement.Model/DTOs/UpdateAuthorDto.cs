
namespace LibraryManagement.Model.DTOs;

public class UpdateAuthorDto : IUpdateDto
{
    public required string Name { get; set; }

    public required DateTime DateOfBirth { get; set; }
}
