using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class AuthorConfig : BaseConfig<Author>
{
    public override void ConfigureEntity(EntityTypeBuilder<Author> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.DateOfBirth)
            .HasColumnType("Date")
            .IsRequired();
    }
}