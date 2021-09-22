using CookBookNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBookNet.Infrastructure.DA.Context
{
    public class CookBookMockDbContext : DbContext
    {
        public CookBookMockDbContext(DbContextOptions<CookBookDbContext> options)
        : base(options)
        {

        }

        public DbSet<Recipe> Customers { get; set; }
        public DbSet<User> Invoices { get; set; }
        public DbSet<Category> InvoiceItems { get; set; }
    }
}
