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

        [HttpGet] //api/recipe?pageSize=10&pageNumber=1

        public async Task<IActionResult> Index([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            return Ok(pageSize + " - " + pageNumber);
        }

        [HttpGet("{recipeId}")] //api/recipe/{recipeId}
        public async Task<IActionResult> Show(Guid recipeId)
        {
            return Ok(recipeId);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] RecipeEntity recipeEntity)
        {
            return Ok(recipeEntity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecipeEntity recipeEntity)
        {
            return Ok(recipeEntity);
        }

        [HttpDelete("recipeId")]
        public async Task<IActionResult> Delete([FromBody] Guid recipeId)
        {
            return Ok(recipeId);
        }
    }
}
