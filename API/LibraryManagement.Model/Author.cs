using System.Text;

namespace LibraryManagement.Model;

public class Author : BaseEntity
{
    public required string Name { get; set; }

    public required DateTime DateOfBirth { get; set; }

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
