using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cintarebis.DAL
{
    public class CinteraContext : DbContext
    {
        public CinteraContext() : base("CinteraDb")
        {

        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Sightging> Sightgings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Sightging>().Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(256);
            base.OnModelCreating(modelBuilder);
        }
    }
}
