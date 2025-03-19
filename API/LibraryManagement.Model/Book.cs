namespace LibraryManagement.Model;

public class Book : BaseEntity
{
    public required string Title { get; set; }

    public required Guid AuthorId { get; set; }
    public required Author Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public string? Genre { get; set; }

    public required List<Category> Categories { set; get; }
}
