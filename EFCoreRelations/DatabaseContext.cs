using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelations
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One {Area} has many {People}.
            modelBuilder.Entity<Area>()
                .HasMany(a => a.People);

            // One {Place} has many {People}.
            modelBuilder.Entity<Place>()
                .HasMany(a => a.People);
        }
    }
}
