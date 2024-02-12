using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using domain.Entities.PDPA;

namespace infra.Persistence.Configuration
{
    public class PdpaPrivacyConfiguration : IEntityTypeConfiguration<PdpaPrivacy>
    {
        public void Configure(EntityTypeBuilder<PdpaPrivacy> entity) 
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnType("int");
            entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");
            entity.Property(e => e.DescriptionTh).HasColumnName("DescriptionTH");
            entity.Property(e => e.DescriptionZh).HasColumnName("DescriptionZH");
            entity.Property(e => e.PpCode)
                .HasMaxLength(10)
                .HasColumnName("PP_Code");
            entity.Property(e => e.Status).HasConversion(new ValueConverter<ulong?, int?>(
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
