using CookBookNet.Domain;
using CookBookNet.Infrastructure.Authentication.PasswordEncryption;
using Microsoft.EntityFrameworkCore;
using System;

namespace CookBookNet.Infrastructure.DA.Context
{
    public class CookBookDbContext : DbContext
    {
        private readonly IPasswordEncryptionProvider passwordProvider;

        public CookBookDbContext(DbContextOptions<CookBookDbContext> options, IPasswordEncryptionProvider passwordProvider)
        : base(options)
        
        {
           
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        
    }
}
