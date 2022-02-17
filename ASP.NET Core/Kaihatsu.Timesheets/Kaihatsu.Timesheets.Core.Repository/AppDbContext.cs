using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kaihatsu.Timesheets.Core.Repository
{
    public class AppDbContext : DbContext //FIX : internal?!
    {
        public AppDbContext(DbContextOptions dbContext) : base(dbContext)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Timesheets;Username=postgres;Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().Ignore(x => x.Comment);
        }

    }
}
