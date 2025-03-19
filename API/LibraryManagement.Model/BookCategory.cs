namespace LibraryManagement.Model;

public class BookCategory : BaseEntity
{
    public Guid BookId { get; set; }

    public Guid CategoryId { get; set; }

}
