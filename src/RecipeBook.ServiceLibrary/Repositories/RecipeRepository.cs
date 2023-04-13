using Dapper;
using Dapper.Contrib.Extensions;
using RecipeBook.ServiceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.ServiceLibrary.Repositories
{
    public interface IRecipeRepository
    {
        Task<int> InsertAsync(RecipeEntity entity);
    }
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IInstructionRepository _instructionRepository;
        private readonly string _connectionString = "server=host.docker.internal,5050;database=RecipeBook;user=sa;password=P@ssword123";

        public RecipeRepository(IIngredientRepository ingredientRepository, IInstructionRepository instructionRepository)
        {
            _ingredientRepository = ingredientRepository;
            _instructionRepository = instructionRepository;
        }

        public async Task<int> InsertAsync(RecipeEntity entity)
        {
            //using (var connection = new SqlConnection("Data Source=sqlserver; Initial Catalog=RecipeBook;User Id=sa;Password=P@ssword123;MultipleActiveResultSets=true;Encrypt=false"))
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = await connection.BeginTransactionAsync())
                {
                    var rowsAffected = await connection.InsertAsync<RecipeEntity>(new RecipeEntity
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        Logo = entity.Logo,
                        CreatedDate = entity.CreatedDate
                    }, transaction);
                    //var rowsAffected = await connection.ExecuteAsync(@"
                    //        INSERT INTO [dbo].[Recipes]
                    //                    ([Id]
                    //                    ,[Title]
                    //                    ,[Description]
                    //                    ,[Logo]
                    //                    ,[CreatedDate])
                    //        VALUES
                    //            (@Id
                    //            ,@Title
                    //            ,@Description
                    //            ,@Logo
                    //            ,@CreatedDate)",
                    //            new
                    //            {
                    //entity.Id,
                    //                entity.Title,
                    //                entity.Description,
                    //                entity.Logo,
                    //                entity.CreatedDate
                    //            }, transaction: transaction);

                    rowsAffected += await _ingredientRepository.InsertManyAsync(connection, transaction, entity.Ingredients);
                    rowsAffected += await _instructionRepository.InsertManyAsync(connection, transaction, entity.Instructions);
                    transaction.Commit();
                    return rowsAffected;
                }
            }

        }
    }
}
