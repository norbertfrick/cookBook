using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace CookBookNetApi.Mappers
{
    public class RecipeMapper : IEntityMapper<RecipeDto, Recipe>
    {
        public Recipe MapFromDto(RecipeDto dto)
        {
            return new Recipe
            {
                Id = dto.Id,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Image = dto.Image,
                Ingredients = JsonSerializer.Serialize(dto.Ingredients),
                Steps = JsonSerializer.Serialize(dto.CookingSteps),
                Title = dto.Title,
                UserId = dto.UserId
            };
        }

        public RecipeDto MapToDto(Recipe entity)
        {
            return new RecipeDto 
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                CookingSteps = JsonSerializer.Deserialize<List<CookingStepDto>>(entity.Steps),
                Ingredients = JsonSerializer.Deserialize<List<IngredientDto>>(entity.Ingredients),
                Title = entity.Title,
                Description = entity.Description,
                UserId = entity.UserId,
                Image = entity.Image
            };
        }
    }
}
