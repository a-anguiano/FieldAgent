using FieldAgent.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }   //plural or not?
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgencyAgent> AgenciesAgents { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<SecurityClearance> SecurityClearances { get; set; }


        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
            //anything?
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AgencyAgent>
                ().ToTable("AgencyAgent").HasKey(aa => new { aa.AgencyId, aa.AgentId });

            //builder.Entity<AgencyAgent>().HasOne(aa => aa.Agency).WithMany(ac => ac.AgencyAgent);

            //builder.Entity<AgencyAgent>()
            //.HasKey(aa => new { aa.AgencyId, aa.AgentId });

            //builder.Entity<Agency>().ToTable("Agency");
            //builder.Entity<Agent>().ToTable("Agent");

            //builder.Entity<Alias>().ToTable("Alias");
            //builder.Entity<Location>().ToTable("Location");
            //builder.Entity<Mission>().ToTable("Mission");
            //builder.Entity<SecurityClearance>().ToTable("SecurityClearance");

            //builder.Entity<Mission>().HasMany(m => m.Agents).WithMany(a => a.Missions).MapToStoredProcedures();
        }
    }
}
