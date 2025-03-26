using System.Text;

namespace LibraryManagement.Model;

public class Book : BaseEntity
{
    public required string Title { get; set; }

    public required Guid AuthorId { get; set; }
    public required Author Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public string? Genre { get; set; }

    public required List<Category> Categories { set; get; }

    protected override bool IsValidEntity(out string validMessage)
    {
        StringBuilder message = new StringBuilder();
        bool isValid = true;

        if (string.IsNullOrEmpty(Title))
        {
            isValid &= false;
            message.Append("Title cannot be empty or null ");
        }

        validMessage = message.ToString();
        return isValid;
    }
}
