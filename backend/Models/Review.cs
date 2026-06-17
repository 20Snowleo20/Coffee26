namespace CoffeeBackend.Models;

public class Review
{
    public string User { get; set; } = "";

    public string City { get; set; } = "";

    public string CoffeeShop { get; set; } = "";

    public string Drink { get; set; } = "";

    public string Milk { get; set; } = "";

    public int? MilkRating { get; set; }

    public string Topping { get; set; } = "";

    public int? ToppingRating { get; set; }

    public int OverallRating { get; set; }

    public int? Bitterness { get; set; }
}