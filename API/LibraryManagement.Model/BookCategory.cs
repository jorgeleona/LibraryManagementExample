using System.Text;

namespace LibraryManagement.Model;

public class BookCategory : BaseEntity
{
    public Guid BookId { get; set; }

    public Guid CategoryId { get; set; }

    protected override bool IsValidEntity(out string validMessage)
    {
        StringBuilder message = new StringBuilder();
        bool isValid = true;

        if (BookId.Equals(Guid.Empty))
        {
            isValid &= false;
            message.Append("BookId cannot be empty ");
        }

        if (CategoryId.Equals(Guid.Empty))
        {
            isValid &= false;
            message.Append("BookId cannot be empty ");
        }

        validMessage = message.ToString();
        return isValid;
    }

}
