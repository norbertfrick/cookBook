using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Domain.Model;

namespace Cookbook.Domain.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        List<Category> GetCategories(Guid recipeId);
    }
}