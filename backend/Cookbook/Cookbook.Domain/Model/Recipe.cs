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

        [ForeignKey("RecipeImage")]
        public Guid TitleImageId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public RecipeImage? TitleImage { get; set; }

        public List<Category> Categories { get; set; }

        [ForeignKey("User")]
        public Guid OwnerId { get; set; }

        public User Owner { get; set; }

        [ForeignKey("RecipeDetail")]
        public Guid RecipeDetailId { get; set; }

        public RecipeDetail Detail { get; set; }



    }
}