using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class ShoppingListItem: Ingredient
    {
        public bool IsChecked { get; set; }
    }
}