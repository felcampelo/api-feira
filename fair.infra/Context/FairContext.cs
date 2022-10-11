using fair.infra.Configuration;
using fair.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fair.infra.Context
{
    public class FairContext : DbContext
    {
        public FairContext(DbContextOptions<FairContext> options) : base(options)
        {

        }

        public DbSet<Fair> Fairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FairConfiguration());
        }
    }
}
