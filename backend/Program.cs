using CoffeeBackend.Models;
using CoffeeBackend.Services;
using CoffeeBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. РЕГИСТРИРУЕМ СЕРВИСЫ
builder.Services.AddSingleton<FileStorage>();
builder.Services.AddCors(); // Разрешаем CORS

var app = builder.Build();

// 2. ПОДКЛЮЧАЕМ CORS (Строго ДО всего остального!)
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// 3. КАСТОМНЫЙ MIDDLEWARE ДЛЯ ФОРМЫ КОНТАКТОВ

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/contact" && context.Request.Method == "POST")
    {
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();

        var filePath = Path.Combine(
    Directory.GetCurrentDirectory(),
    "Data",
    "contacts.txt"
);
        Directory.CreateDirectory("Data");

        // Сохраняем с датой и временем
        await File.AppendAllTextAsync(filePath, $"[{DateTime.Now}]\n{body}\n\n");

        context.Response.StatusCode = 200;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("OK");
        return; // Прерываем pipeline
    }
    await next();
});

// 4.  AUTH MIDDLEWARE 
app.UseMiddleware<AuthMiddleware>();

// 5. РЕГИСТРАЦИЯ
app.MapPost("/register",
(User user, FileStorage storage) =>
{
    if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
    {
        return Results.BadRequest("Login and password required");
    }

    var users = storage.GetUsers();

    if (users.Any(x => x.Login == user.Login))
    {
        return Results.BadRequest("User already exists");
    }

    users.Add(user);
    storage.SaveUsers(users);

    return Results.Ok();
});

// 6. ВХОД
app.MapPost("/login",
(User user, FileStorage storage) =>
{
    var users = storage.GetUsers();

    var foundUser = users.FirstOrDefault(x =>
        x.Login == user.Login &&
        x.Password == user.Password);

    if (foundUser == null)
    {
        return Results.Unauthorized();
    }

    return Results.Json(new
    {
        token = foundUser.Login,
        user = foundUser.Login
    });
});

// 7. ПОЛУЧЕНИЕ ОТЗЫВОВ
app.MapGet("/reviews",
(FileStorage storage) =>
{
    return Results.Ok(storage.GetReviews());
});

// 8. ДОБАВЛЕНИЕ ОТЗЫВА (требует авторизации)
app.MapPost("/reviews",
(
    Review review,
    HttpContext context,
    FileStorage storage
) =>
{
    bool auth = (bool?)context.Items["auth"] ?? false;

    if (!auth)
    {
        return Results.Json(new { message = "Unauthorized" }, statusCode: 403);
    }

    string token = context.Request.Headers["token"]!;
    review.User = token;

    var reviews = storage.GetReviews();
    reviews.Add(review);
    storage.SaveReviews(reviews);

    return Results.Ok();
});
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/contact" &&
        context.Request.Method == "POST")
    {
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();

        var basePath = AppContext.BaseDirectory;
        var folder = Path.Combine(basePath, "Data");
        var filePath = Path.Combine(folder, "contacts.txt");

        Directory.CreateDirectory(folder);

        await File.AppendAllTextAsync(filePath,
            $"[{DateTime.Now}]\n{body}\n\n");

        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("OK");
        return;
    }

    await next();
});

// 9. ЗАПУСК ПРИЛОЖЕНИЯ
app.Run();