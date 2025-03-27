

namespace LibraryManagement.Model.DTOs;

public class UpdateBookDto : IUpdateDto
{
    public required string Title { get; set; }

    public required DateTime PublishedDate { get; set; }
}
