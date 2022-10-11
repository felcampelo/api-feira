using fair.infra.Configuration;
using feira.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feira.infra.Context
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
