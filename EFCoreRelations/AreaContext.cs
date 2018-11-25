using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelations
{
    public class AreaContext : DbContext
    {
        public DbSet<AreaEntity> Areas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One {Area} has many {People}.
            modelBuilder.Entity<AreaEntity>()
                .HasMany(a => a.People);
        }
    }

    [Table("Area")]
    public class AreaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public ICollection<PersonEntity> People { get; set; }
    }
}
