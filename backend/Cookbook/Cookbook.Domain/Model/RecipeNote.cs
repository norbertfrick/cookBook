using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class RecipeNotes
    {
        public Guid Id { get; set; }

        public string Note { get; set; }

        public Guid RecipeId { get; set; }

        public Recipe? Recipe { get; set; }

        public Guid UserId { get; set; }

        public User? User { get; set; }
    }
}