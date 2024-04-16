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
            builder.Entity<EquipmentBase>(ConfigureEquipmentBase);
            builder.Entity<Exercise>(ConfigureExercise);
            builder.Entity<Sign>(ConfigureSign);
            builder.Entity<Track>(ConfigureTrack);
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever(); // This line configures the ID to not be database-generated.
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Exercises).WithOne(e => e.Category);
            builder.HasMany(c => c.Tracks).WithOne(t => t.Category);
        }

        private void ConfigureEquipmentBase(EntityTypeBuilder<EquipmentBase> builder)
        {
            builder.ToTable("EquipmentBases");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasMany(e => e.Equipments).WithOne(e => e.EquipmentBase);
            builder.HasMany(e => e.Exercises).WithOne(e => e.EquipmentBase);
        }

        private void ConfigureExercise(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasOne(e => e.Category).WithMany(c => c.Exercises);
            builder.HasOne(e => e.EquipmentBase).WithMany(e => e.Exercises);
        }  

        private void ConfigureEquipment(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasOne(e => e.EquipmentBase).WithMany(e => e.Equipments);
        }

        private void ConfigureSign(EntityTypeBuilder<Sign> builder)
        {
            builder.ToTable("Signs");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Track).WithMany(t => t.Signs);
        }

        private void ConfigureTrack(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Tracks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Date).ValueGeneratedOnAdd(); // NOTE Date only gets set when its first added to database
            builder.HasOne(t => t.Category).WithMany(c => c.Tracks);
            builder.HasMany(t => t.Signs).WithOne(s => s.Track);
        }
    }

}

