using System.Text;

namespace LibraryManagement.Model;

public abstract class BaseEntity
{
    public Guid Id { set; get; }

    public required bool IsActive { set; get; }

    public DateTime CreatedOn { set; get; }

    public DateTime LastModificationOn { set; get; }

    public bool IsValid(out string validMessage)
    {
        StringBuilder message = new StringBuilder();
        bool isValid = true;

        if (Id.Equals(Guid.Empty))
        {
            isValid &= false;
            message.Append("Id cannot be empty ");
        }

        if (!IsValidEntity(out string validEntityMessage))
        {
            isValid &= false;
            message.Append(validEntityMessage);
        }

        validMessage = message.ToString();
        return isValid;
    }

    protected abstract bool IsValidEntity(out string validMessage);

    public void UpdateLastModified()
    {
        LastModificationOn = DateTime.UtcNow;
    }
}


