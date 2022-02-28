using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kaihatsu.Timesheets.Core.Repository
{
    public class AppDbContext : DbContext //FIX : internal?!
    {
        public AppDbContext(DbContextOptions dbContext) : base(dbContext)
        {            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Timesheets;Username=postgres;Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
