using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class BaseConfig<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");

        builder.Property(e => e.CreatedOn)
            .HasColumnType("Date")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.LastModificationOn)
            .HasColumnType("Date")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true);

        ConfigureEntity(builder);
    }

    public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}

