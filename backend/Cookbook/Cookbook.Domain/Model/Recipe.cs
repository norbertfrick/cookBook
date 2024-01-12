using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public List<CookingStep> Steps {get;set;}

        public List<Ingredient> Ingredients {get;set;}

        public List<RecipeImage> Images {get;set;}

        public List<RecipeCategory> Categories {get;set;}

        public User Owner {get;set;}

        [ForeignKey("User")]
        public Guid OwnerId {get;set;}



    }
}