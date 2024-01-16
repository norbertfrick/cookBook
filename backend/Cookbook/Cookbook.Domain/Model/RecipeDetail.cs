using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class RecipeDetail
    {
        public Guid Id { get; set; }

        public List<CookingStep> Steps { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<RecipeNotes>? Notes { get; set; }

        public int? NumberOfPortions { get; set; }

    }
}