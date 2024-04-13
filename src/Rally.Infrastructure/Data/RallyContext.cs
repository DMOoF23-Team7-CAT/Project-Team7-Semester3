using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rally.Core.Entities;

namespace Rally.Infrastructure.Data
{
    public class RallyContext : DbContext
    {
        public RallyContext(DbContextOptions<RallyContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentBase> EquipmentBases { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Sign> Signs { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(ConfigureCategory);
            builder.Entity<Equipment>(ConfigureEquipment);

            // TODO implement Data Context methods
            // builder.Entity<EquipmentBase>(ConfigureEquipmentBase);
            // builder.Entity<Exercise>(ConfigureExercise);
            // builder.Entity<Sign>(ConfigureSign);
            // builder.Entity<Track>(ConfigureTrack);
        }
        
        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Exercises).WithOne(e => e.Category);
            builder.HasMany(c => c.Tracks).WithOne(t => t.Category);
        }

        private void ConfigureEquipment(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.EquipmentBase).WithMany()
            .HasForeignKey(e => e.EquipmentBase!.Id); 
            //NOTE the null forgiving operator (!) means that the property is not 
            // nullable since Equipment should always be related to a EquipmentBase
        }
    }

}

