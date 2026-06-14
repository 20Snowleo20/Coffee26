using CoffeeBackend.Services;

namespace CoffeeBackend.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate next;

    public AuthMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        FileStorage storage)
    {
        string path =
            context.Request.Path.Value ?? "";

        if (
            path.StartsWith("/login") ||
            path.StartsWith("/register") ||
            path.StartsWith("/reviews")
                && context.Request.Method == "GET"
        )
        {
            await next(context);
            return;
        }

        string token =
            context.Request.Headers["token"]!;

        bool auth = false;

        if (!string.IsNullOrWhiteSpace(token))
        {
            var users =
                storage.GetUsers();

            auth = users.Any(x =>
                x.Login == token);
        }

        context.Items["auth"] = auth;

        await next(context);
    }
}