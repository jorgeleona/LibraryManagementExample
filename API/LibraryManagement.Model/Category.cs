namespace LibraryManagement.Model;

public class Category : BaseEntity
{
    public required string Name { get; set; }

    public required List<Book> Books { set; get; }

}
