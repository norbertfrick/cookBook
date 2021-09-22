using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookNetApi.Mappers
{
    public class RecipeMapper : IEntityMapper<RecipeDto, Recipe>
    {
        public Recipe MapFromDto(RecipeDto dto)
        {
            throw new NotImplementedException();
        }

        public RecipeDto MapToDto(Recipe entity)
        {
            throw new NotImplementedException();
        }
    }
}
