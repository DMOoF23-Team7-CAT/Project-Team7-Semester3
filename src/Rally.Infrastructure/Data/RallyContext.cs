using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rally.Core.Entities;
using Rally.Core.Entities.Account;

namespace Rally.Infrastructure.Data
{
    public class RallyContext : IdentityDbContext<User>
    {
        public RallyContext(DbContextOptions<RallyContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentBase> EquipmentBases { get; set; }
        public DbSet<SignBase> SignBases { get; set; }
        public DbSet<Sign> Signs { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>(ConfigureCategory);
            builder.Entity<Equipment>(ConfigureEquipment);
            builder.Entity<EquipmentBase>(ConfigureEquipmentBase);
            builder.Entity<SignBase>(ConfigureSignBase);
            builder.Entity<Sign>(ConfigureSign);
            builder.Entity<Track>(ConfigureTrack);

            builder.Entity<User>()
                .HasMany(u => u.Tracks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever(); // This line configures the ID to not be database-generated.
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.SignBases).WithOne(e => e.Category).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Tracks).WithOne(t => t.Category).OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureEquipmentBase(EntityTypeBuilder<EquipmentBase> builder)
        {
            builder.ToTable("EquipmentBases");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasMany(e => e.Equipments).WithOne(e => e.EquipmentBase).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.SignBases).WithOne(e => e.EquipmentBase).OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureSignBase(EntityTypeBuilder<SignBase> builder)
        {
            builder.ToTable("SignBases");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasOne(e => e.Category).WithMany(c => c.SignBases).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.EquipmentBase).WithMany(e => e.SignBases).OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureEquipment(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasOne(e => e.EquipmentBase).WithMany(e => e.Equipments).OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureSign(EntityTypeBuilder<Sign> builder)
        {
            builder.ToTable("Signs");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Track).WithMany(t => t.Signs).OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureTrack(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Tracks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Date).ValueGeneratedOnAdd(); // NOTE Date only gets set when its first added to database
            builder.HasOne(t => t.Category).WithMany(c => c.Tracks).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(t => t.Signs).WithOne(s => s.Track).OnDelete(DeleteBehavior.Cascade);
        }
    }

}

