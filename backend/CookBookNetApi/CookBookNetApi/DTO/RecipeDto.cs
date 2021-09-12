using CookBookNet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookNetApi
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public List<CookingStep> Steps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Guid UserId { get; set; }
        //public string ImagePath { get; set; }
        public IFormFile Image { get; set; }

        }



    }
}
