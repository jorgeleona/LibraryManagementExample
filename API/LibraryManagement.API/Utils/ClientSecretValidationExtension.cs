
using System.Globalization;

namespace LibraryManagement.API.Utils;

public static class ClientSecretValidationExtension
{
    public static IApplicationBuilder UseClientSecretValidation(this IApplicationBuilder app)
    {
        app.UseMiddleware<ClientSecretValidationMiddleware>();
        return app;
    }
}
