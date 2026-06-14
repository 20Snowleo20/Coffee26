using System.Text.Json;
using CoffeeBackend.Models;

namespace CoffeeBackend.Services;

public class FileStorage
{
    private readonly string usersPath;
    private readonly string reviewsPath;

    public FileStorage(IWebHostEnvironment env)
    {
        string dataFolder =
            Path.Combine(env.ContentRootPath, "Data");

        Directory.CreateDirectory(dataFolder);

        usersPath =
            Path.Combine(dataFolder, "users.json");

        reviewsPath =
            Path.Combine(dataFolder, "reviews.json");

        if (!File.Exists(usersPath))
            File.WriteAllText(usersPath, "[]");

        if (!File.Exists(reviewsPath))
            File.WriteAllText(reviewsPath, "[]");
    }

    public List<User> GetUsers()
    {
        string json = File.ReadAllText(usersPath);

        return JsonSerializer.Deserialize<List<User>>(json)
               ?? new List<User>();
    }

    public void SaveUsers(List<User> users)
    {
        File.WriteAllText(
            usersPath,
            JsonSerializer.Serialize(users));
    }

    public List<Review> GetReviews()
    {
        string json = File.ReadAllText(reviewsPath);

        return JsonSerializer.Deserialize<List<Review>>(json)
               ?? new List<Review>();
    }

    public void SaveReviews(List<Review> reviews)
    {
        File.WriteAllText(
            reviewsPath,
            JsonSerializer.Serialize(reviews));
    }
}