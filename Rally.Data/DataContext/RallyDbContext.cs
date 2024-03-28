using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rally.Domain.Entity;

namespace Rally.Data.DataContext
{
    public class RallyDbContext : DbContext
    {
        public RallyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Sign> Signs { get; set; }
    }
}