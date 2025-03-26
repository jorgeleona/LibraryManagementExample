using System.Text;

namespace LibraryManagement.Model;

public class Category : BaseEntity
{
    public required string Name { get; set; }

    public required List<Book> Books { set; get; }

    protected override bool IsValidEntity(out string validMessage)
    {
        StringBuilder message = new StringBuilder();
        bool isValid = true;

        if (string.IsNullOrEmpty(Name))
        {
            isValid &= false;
            message.Append("Name cannot be empty or null ");
        }

        validMessage = message.ToString();
        return isValid;
    }

}
