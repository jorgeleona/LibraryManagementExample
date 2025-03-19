namespace LibraryManagement.Model;

public class Author : BaseEntity
{
    public required string Name { get; set; }

    public required DateTime DateOfBirth { get; set; }
}
