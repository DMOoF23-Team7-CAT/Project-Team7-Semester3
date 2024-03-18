using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rally.Api.Models;

namespace Rally.Api.Data
{
    public class RallyDbContext : DbContext
    {
        public RallyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        DbSet<Category> categories { get; set; }
        DbSet<CategoryType> CategoryTypes { get; set; }
        DbSet<Equipment> Equipments { get; set; }
        DbSet<EquipmentType> EquipmentTypes { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<ExerciseType> ExerciseTypes { get; set; }
        DbSet<Track> Tracks { get; set; }
    }
}