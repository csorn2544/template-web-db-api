using Microsoft.EntityFrameworkCore;

public class _dbContext : DbContext
{
  public DbSet<PdpaPrivacy> PdpaPrivacies { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<PdpaConsent> PdpaConsents { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public _dbContext(DbContextOptions<_dbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
