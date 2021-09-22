using CookBookNet.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookBookNet.Infrastructure.DA.Context
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options)
        : base(options)
        
        { }
        public DbSet<Recipe> Customers { get; set; }
        public DbSet<User> Invoices { get; set; }
        public DbSet<Category> InvoiceItems { get; set; }
    }
}
