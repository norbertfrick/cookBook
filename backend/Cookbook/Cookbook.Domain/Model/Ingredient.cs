using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Domain.Enums;

namespace Cookbook.Domain.Model
{
    public class Ingredient
    {
        public string Name { get; set; }

        public eQuantityUnit eQuantityUnit { get; set; }

        public float Amount { get; set;}
    }
}