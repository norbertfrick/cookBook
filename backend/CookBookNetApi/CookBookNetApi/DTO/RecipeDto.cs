using CookBookNet.Domain;
using CookBookNet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookBookNetApi
{
    public class RecipeDto
    {
        public RecipeDto() { }

        public RecipeDto(Recipe r)
        {
            this.Id = r.Id;
            this.Title = r.Title;
            this.CategoryId = r.CategoryId;
            this.Description = r.Description;
            this.CookingSteps = JsonSerializer.Deserialize<List<CookingStep>>(r.Steps);
            this.Ingredients = JsonSerializer.Deserialize<List<Ingredient>>(r.Ingredients);
            this.UserId = r.UserId;
            this.Image = r.Image;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public List<CookingStep> CookingSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }

    }
}
