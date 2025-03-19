using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class CategoryConfig : BaseConfig<Category>
{
    public override void ConfigureEntity(EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(e => e.Books)
            .WithMany(e => e.Categories)
            .UsingEntity<BookCategory>();
    }
}