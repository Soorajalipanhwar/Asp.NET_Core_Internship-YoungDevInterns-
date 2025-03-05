using RecipeManager.Models;
using RecipeManager.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace RecipeManager.Repository;

public interface IRecipeRepository
{
    Task<List<Recipe>> GetAllRecipesAsync();
    Task<Recipe> GetRecipeByIdAsync(int id);
    Task AddRecipeAsync(Recipe recipe);
    Task UpdateRecipeAsync(Recipe recipe);
    Task DeleteRecipeAsync(int id);
}
public class RecipeRepository : IRecipeRepository
{
    private readonly RecipeDbContext _context;
    public RecipeRepository(RecipeDbContext context) => _context = context;

    public async Task<List<Recipe>> GetAllRecipesAsync() => await _context.Recipes.ToListAsync();
    public async Task<Recipe> GetRecipeByIdAsync(int id) => await _context.Recipes.FindAsync(id);
    public async Task AddRecipeAsync(Recipe recipe) { _context.Recipes.Add(recipe); await _context.SaveChangesAsync(); }
    public async Task UpdateRecipeAsync(Recipe recipe) { _context.Recipes.Update(recipe); await _context.SaveChangesAsync(); }
    public async Task DeleteRecipeAsync(int id) { var recipe = await _context.Recipes.FindAsync(id); if (recipe != null) { _context.Recipes.Remove(recipe); await _context.SaveChangesAsync(); } }
}