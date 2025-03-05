using Microsoft.EntityFrameworkCore;

namespace RecipeManager.Models.Data;

public class RecipeDbContext:DbContext
{
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options):base(options){}
    public DbSet<Recipe> Recipes {get; set;}
}
