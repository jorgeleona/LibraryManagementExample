namespace LibraryManagement.Model;

public abstract class BaseEntity
{
    public Guid Id { set; get; }

    public required bool IsActive { set; get; }

    public DateTime CreatedOn { set; get; }

    public DateTime LastModificationOn { set; get; }
}


