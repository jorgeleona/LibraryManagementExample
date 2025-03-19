using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class BookConfig : BaseConfig<Book>
{
    public override void ConfigureEntity(EntityTypeBuilder<Book> builder)
    {
        builder.Property(e => e.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.Genre)
            .HasMaxLength(100);

        builder.Property(e => e.PublishedDate)
            .HasColumnType("Date")
            .IsRequired();

        builder.HasOne(e => e.Author)
            .WithOne()
            .HasForeignKey<Book>(e => e.AuthorId);


        builder.HasMany(e => e.Categories)
            .WithMany(e => e.Books)
            .UsingEntity<BookCategory>();
    }
}