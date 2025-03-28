

namespace LibraryManagement.Model.DTOs;

public class AddBookDto : IAddDto
{
    public required string Title { get; set; }

    public required DateTime PublishedDate { get; set; }
}
