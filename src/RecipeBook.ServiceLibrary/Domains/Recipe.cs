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
        public void SaveRecipe(RecipeEntity recipeEntity)
        {
            var recipeRepository = new RecipeRepository();
            recipeRepository.SaveRecipeToDatabase(recipeEntity);
        }
    }
}
