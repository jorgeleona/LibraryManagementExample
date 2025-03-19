using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using LibraryManagement.Model;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

public class LibraryManagementContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    private readonly string _connectionString;

    public LibraryManagementContext()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        _connectionString = configuration.GetRequiredSection("ConnectionStrings")["LibraryManagement"] ?? throw new InvalidOperationException("Connection string 'LibraryManagement' not found.");
    }

    public LibraryManagementContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
          : base(options)
    {
        _connectionString = string.Empty;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured && !string.IsNullOrEmpty(_connectionString))
            options.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AuthorConfig().Configure(modelBuilder.Entity<Author>());
        new BookConfig().Configure(modelBuilder.Entity<Book>());
        new CategoryConfig().Configure(modelBuilder.Entity<Category>());
    }
}