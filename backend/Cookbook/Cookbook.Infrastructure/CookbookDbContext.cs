using Cookbook.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Infrastructure
{
    public class CookbookDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserRefreshToken> RefreshTokens { get; set; }

        public CookbookDbContext() : base() { }

        public CookbookDbContext(DbContextOptions<CookbookDbContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Cookbook;Trusted_Connection=True;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
