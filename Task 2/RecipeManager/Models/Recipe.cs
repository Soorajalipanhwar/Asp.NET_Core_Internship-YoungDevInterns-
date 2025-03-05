namespace RecipeManager.Models;

public class Recipe
{
         public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Ingredients { get; set; }
    public string? Instructions { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;    
}