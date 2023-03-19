using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.ServiceLibrary.Domains;
using RecipeBook.ServiceLibrary.Entities;

namespace RecipeBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddNewRecipe([FromBody]RecipeEntity recipeEntity)
        {
            var domain = new Recipe();
            domain.SaveRecipe(recipeEntity);
            return Ok();  
        }
    }
}
