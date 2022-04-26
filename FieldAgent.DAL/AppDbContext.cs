using FieldAgent.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FieldAgent.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }   
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
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AgencyAgent>
                ().ToTable("AgencyAgent").HasKey(aa => new { aa.AgencyId, aa.AgentId });

            builder.Entity<MissionAgent>
                ().ToTable("MissionAgent").HasKey(ma => new { ma.MissionId, ma.AgentId });

            //// Add the shadow property to the model
            //builder.Entity<AgencyAgent>()
            //    .Property<int>("SecurityClearanceId");

            //// Use the shadow property as a foreign key
            //builder.Entity<AgencyAgent>()
            //    .HasOne(aa => aa.SecurityClearance)
            //    .HasForeignKey("SecurityClearanceId");

            //builder.Entity<Agency>()
            //    .Navigation(ac => ac.Locations).UsePropertyAccessMode(PropertyAccessMode.Property);

            //builder.Entity<AgencyAgent>()
            //    .Navigation(aa => aa.SecurityClearance).UsePropertyAccessMode(PropertyAccessMode.Property);
            //builder.Entity<Agency>().HasRequired(t => t.Location)WillCascadeOnDelete(true);
            //builder.Entity<AgencyAgent>().HasOne(aa => aa.Agency).WithMany(ac => ac.AgencyAgent);

            //builder.Entity<Mission>().HasMany(m => m.Agents).WithMany(a => a.Missions).MapToStoredProcedures();

            //builder.Entity<AgencyAgent>().HasForeignKey(p => p.SecurityClearanceId);

            //builder.Entity<AgencyAgent>().HasRequired(t => t.SecurityClearance).WithMany().HasForeignKey(t => t.SecurityClearanceId)
        }
    }
}
