using api_bank.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace api_bank.infraestructure.Factory
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ExtractEntity> ExtractEntities { get; set; }
        public DbSet<BankEntity> BankEntities { get; set; }
        public DbSet<CustomerEntity> CustomerEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}