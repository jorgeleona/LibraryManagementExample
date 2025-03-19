namespace LibraryManagement.API.Utils;

public class ClientSecretValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ClientSecretValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? apiKey = context.Request.Headers["x-api-key"];
        IConfiguration? configuration = context.RequestServices.GetService<IConfiguration>();
        string? webClientSecret = configuration?["Keys:WebClientSecret"];

        if (string.IsNullOrEmpty(apiKey)
            || string.IsNullOrEmpty(webClientSecret))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("No API Key Provided");
            return;
        }

        if (!apiKey.Equals(webClientSecret))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid API Key Provided");
            return;
        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}
