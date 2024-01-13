using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class ShoppingList
    {
        public Guid Id { get; set; }

        public List<ShoppingListItem> Items { get; set; }

        public Guid UserId { get; set; }
    }
}