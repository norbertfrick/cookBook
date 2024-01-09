using CookBookNet.Domain;
using CookBookNet.Infrastructure.Authentication.PasswordEncryption;
using CookBookNet.Infrastructure.DA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.DA
{
    public class MockDataGenerator
    {
        private readonly CookBookDbContext context;
        private readonly IPasswordEncryptionProvider passwordProvider;

        public MockDataGenerator(CookBookDbContext context, IPasswordEncryptionProvider passwordProvider)
        {
            this.context = context;
            this.passwordProvider = passwordProvider;

        }

        public void Initialize()
        {
            var categoryGuid = Guid.Parse("d0f9b536-c0e2-4c64-9c6f-d91f0904b037");
            var userGuid = Guid.Parse("f4ca0299-ba6d-4010-aa70-5678548e78ba");

            this.GenerateCategories(categoryGuid);
            this.GenerateUsers(userGuid);
            this.GenerateRecipes(categoryGuid, userGuid);

            context.SaveChanges();
        }
        private void GenerateUsers(Guid userGuid)
        {
            this.passwordProvider.CreatePasswordHash("admin", out var hash, out var salt);

            context.Users.AddRange(
                new User { Email = "admin@test.com", FirstName = "Johhny", LastName = "McTestin", Id = userGuid, UserName = "admin", PasswordHash = hash, PasswordSalt = salt }

            );
        }

        private void GenerateRecipes(Guid categoryGuid, Guid userGuid)
        {
            context.Recipes.Add(
                new Recipe
                {
                    CategoryId = categoryGuid,
                    Description = "Best goddam lasagna u ever had",
                    Id = Guid.NewGuid(),
                    Ingredients = "[{\"Amount\": 10, \"Unit\": \"kg\", \"Description\": \"kokotin\"}] ",
                    Title = "Aw8some fucking lasagna",
                    UserId = userGuid,
                    Steps = "[{\"OrderNumber\": 1, \"Description\": \"Zvar tak aby dobre bolo\"}]",

                });
        }

        private void GenerateCategories(Guid categoryGuid)
        {
            context.Categories.Add(new Category { Id = categoryGuid, Name = "General", Description = "A general category for testing purposes" });
        }


    }
}
