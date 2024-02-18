using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rally.Models;

    public class RallyDbContext : DbContext
    {
        public RallyDbContext (DbContextOptions<RallyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rally.Models.User> User { get; set; } = default!;
    }
