using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelations
{
    public class PlaceContext : DbContext
    {
        public DbSet<PlaceEntity> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One {Place} has many {People}.
            modelBuilder.Entity<PlaceEntity>()
                .HasMany(a => a.People);
        }
    }

    [Table("Place")]
    public class PlaceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public ICollection<PersonEntity> People { get; set; }
    }
}
