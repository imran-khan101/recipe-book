using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.ServiceLibrary.Entities
{
    public class IngredientEntity
    {
        public Guid RecipeId { get; set; }
        public int OrdinalPosition { get; set; }
        public string Unit { get; set; }
        public float Quantity { get; set; }
        public string Ingredient { get; set; }
    }
}

