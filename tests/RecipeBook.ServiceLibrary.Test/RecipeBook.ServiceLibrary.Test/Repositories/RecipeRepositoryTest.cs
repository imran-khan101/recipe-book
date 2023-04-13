using RecipeBook.ServiceLibrary.Repositories;
using RecipeBook.ServiceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using RecipeBook.ServiceLibrary.Domains;

namespace RecipeBook.ServiceLibrary.Test.Repositories
{
    public class RecipeRepositoryTest
    {
        private bool _commitToDatabase = false;

        [Fact]
        public async Task InsertAsync_Success()
        {
            var recipeRepository = new RecipeRepository(new IngredientRepository(),new InstructionRepository());
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipeId = Guid.NewGuid();
                var rowsAffected = await recipeRepository.InsertAsync(new RecipeEntity()
                {
                    Id = recipeId,
                    Title = "Fried Chicken Title",
                    Description = "Fried Chicken Description",
                    Logo = null,
                    CreatedDate = DateTimeOffset.UtcNow,
                    Ingredients = new List<IngredientEntity>(){
                        new IngredientEntity()
                        {
                            RecipeId = recipeId,
                            OrdinalPosition = 0,
                            Ingredient = "Chicken",
                            Quantity = 1,
                            Unit = "lbs",
                        }
                    },
                    Instructions = new List<InstructionEntity>(){
                        new InstructionEntity()
                        {
                            RecipeId = recipeId,
                            OrdinalPosition = 0,
                            Instruction = "Cook it"
                        }
                    }
                });
                if (_commitToDatabase)
                {
                    scope.Complete();
                }
                Assert.Equal(3, rowsAffected);
            }

        }
    }
}
