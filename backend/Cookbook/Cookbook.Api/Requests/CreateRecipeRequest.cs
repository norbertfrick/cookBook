using Cookbook.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Api.Requests
{
    public class CreateRecipeRequest
    {
        [Required]
        public Guid UserdId { get; set; }

        public IFormFile? TitleImage { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public List<CookingStep> Steps { get; set; }

        [Required]
        public List<Ingredient> Ingredients { get; set; }

        public int? NumberOfPortions { get; set; }
    }
}
