﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Data
{
    public class SacramentPlannerContext : DbContext
    {
        public SacramentPlannerContext (DbContextOptions<SacramentPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentPlanner.Models.SacramentPlan> SacramentPlan { get; set; }

        public DbSet<SacramentPlanner.Models.Hymn> Hymn { get; set; }

        public DbSet<SacramentPlanner.Models.Speaker> Speaker { get; set; }
    }
}
