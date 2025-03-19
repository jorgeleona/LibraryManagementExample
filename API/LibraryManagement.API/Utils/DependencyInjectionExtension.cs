using LibraryManagement.Services;
using LibraryManagement.Data.Repositories;

namespace LibraryManagement.API.Utils;

public static class DependencyInjectionExtension
{

    public static IServiceCollection AddLibraryManagementRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
    public static IServiceCollection AddLibraryManagementServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }


}
