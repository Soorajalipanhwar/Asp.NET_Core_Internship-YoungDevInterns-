using Microsoft.AspNetCore.Mvc;
using RecipeManager.Models;
using RecipeManager.Repository;

namespace RecipeManager.Controllers;

// [Route("[controller]")]
public class RecipesController : Controller
{
    private readonly IRecipeRepository _repository;

    public RecipesController(IRecipeRepository repository)
    {
        _repository = repository;
    }
    public async Task<IActionResult> Home()
    {
        var recipes = await _repository.GetAllRecipesAsync();
    if (recipes == null)
    {
        recipes = new List<Recipe>(); // Ensure it's never null
    }
    
    return View(recipes);
    }

    // GET: Recipes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Recipes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Recipe recipe)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddRecipeAsync(recipe);
            return RedirectToAction(nameof(Home));
        }
        return View(recipe);
    }

    // GET: Recipes/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var recipe = await _repository.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View(recipe);
    }

    // POST: Recipes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Recipe recipe)
    {
        if (id != recipe.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _repository.UpdateRecipeAsync(recipe);
            return RedirectToAction(nameof(Home));
        }
        return View(recipe);
    }

    // GET: Recipes/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var recipe = await _repository.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View(recipe);
    }

    // POST: Recipes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _repository.DeleteRecipeAsync(id);
        return RedirectToAction(nameof(Home));
    }
    public async Task<IActionResult> Details(int id)
    {
        var recipe = await _repository.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View(recipe);
    }
}