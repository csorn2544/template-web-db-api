using domain.Entities.PDPA;
using infra.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace infra.Persistence
{
    public class _dbContext : DbContext
    {
        public _dbContext()
        {
        }
        public _dbContext(DbContextOptions<_dbContext> options) 
            : base(options) 
        { 
        }
        #region PDPA
        public virtual DbSet<PdpaConsent> PdpaConsents { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PdpaConsentConfiguration());
        }
    }
}
