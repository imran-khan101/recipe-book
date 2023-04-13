using RecipeBook.ServiceLibrary.Entities;
using RecipeBook.ServiceLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.ServiceLibrary.Domains
{
    public class Recipe
    {
        public async Task<int> SaveRecipeAsync(RecipeEntity recipeEntity)
        {
            var ingredientRepository = new IngredientRepository();
            var instructionRepository = new InstructionRepository();
            var recipeRepository = new RecipeRepository(ingredientRepository, instructionRepository);
            return await recipeRepository.InsertAsync(recipeEntity);
        }
    }
}
