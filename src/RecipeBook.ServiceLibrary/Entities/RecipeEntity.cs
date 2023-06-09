﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.ServiceLibrary.Entities
{
    [Table("Recipes")]
    public class RecipeEntity
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public IList<IngredientEntity> Ingredients { get; set; } = new List<IngredientEntity>();
        public IList<InstructionEntity> Instructions { get; set; } = new List<InstructionEntity>();
    }
}
