using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.PDPA;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebAPI.Persistence.Configuration
{
    public class PdpaConsentConfiguration : IEntityTypeConfiguration<PdpaConsent>
    {
        public void Configure(EntityTypeBuilder<PdpaConsent> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pdpa_consent");

            entity.Property(e => e.Id).HasColumnType("int");
            entity.Property(e => e.ConCode)
                .HasMaxLength(10)
                .HasColumnName("Con_Code");

            entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");
            entity.Property(e => e.DescriptionTh).HasColumnName("DescriptionTH");
            entity.Property(e => e.DescriptionZh).HasColumnName("DescriptionZH");
            entity.Property(x => x.Status).HasConversion(new ValueConverter<ulong?, int?>(
            v => (int?)v,
            v => (ulong?)v
            ));
            entity.Property(e => e.TitleEn).HasColumnName("TitleEN");
            entity.Property(e => e.TitleTh).HasColumnName("TitleTH");
            entity.Property(e => e.TitleZh).HasColumnName("TitleZH");
            entity.Property(e => e.Version).HasMaxLength(10);
        }
    }   
}
