using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.DTO
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }

        public string TitleImageUrl { get; set;}

        public Guid OwnerId { get; set; }

        public Guid DetailId { get; set; }
    }
}
