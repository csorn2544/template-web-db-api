using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using WebAPI.Models.PDPA;
using WebAPI.Persistence.Configuration;

namespace WebAPI.Persistence
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
