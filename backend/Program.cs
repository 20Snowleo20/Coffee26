using CoffeeBackend.Models;
using CoffeeBackend.Services;
using CoffeeBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<FileStorage>();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseMiddleware<AuthMiddleware>();

app.MapPost("/register",
(User user, FileStorage storage) =>
{
    if (
        string.IsNullOrWhiteSpace(user.Login) ||
        string.IsNullOrWhiteSpace(user.Password)
    )
    {
        return Results.BadRequest(
            "Login and password required");
    }

    var users = storage.GetUsers();

    if (users.Any(x =>
        x.Login == user.Login))
    {
        return Results.BadRequest(
            "User already exists");
    }

    users.Add(user);

    storage.SaveUsers(users);

    return Results.Ok();
});

app.MapPost("/login",
(User user, FileStorage storage) =>
{
    var users = storage.GetUsers();

    var foundUser =
        users.FirstOrDefault(x =>
            x.Login == user.Login &&
            x.Password == user.Password);

    if (foundUser == null)
    {
        return Results.Unauthorized();
    }

    return Results.Json(
        new
        {
            token = foundUser.Login,
            user = foundUser.Login
        });
});
app.MapGet("/reviews",
(FileStorage storage) =>
{
    return Results.Ok(
        storage.GetReviews());
});

app.MapPost("/reviews",
(
Review review,
HttpContext context,
FileStorage storage
) =>
{
    bool auth =
        (bool?)context.Items["auth"] ?? false;

    if (!auth)
    {
        return Results.Json(
            new
            {
                message = "Unauthorized"
            },
            statusCode: 403);
    }

    string token =
        context.Request.Headers["token"]!;

    review.User = token;

    var reviews =
        storage.GetReviews();

    reviews.Add(review);

    storage.SaveReviews(reviews);

    return Results.Ok();
});

app.Run();