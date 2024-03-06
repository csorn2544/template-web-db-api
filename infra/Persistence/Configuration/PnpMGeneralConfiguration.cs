using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities.Pnp;

namespace infra.Persistence.Configuration
{
    public class PnpMGeneralConfiguration : IEntityTypeConfiguration<PnpMGeneral>
    {
        public void Configure(EntityTypeBuilder<PnpMGeneral> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pnp_m_general");

            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DeletedFlag)
                .HasColumnType("bigint")
                .HasColumnName("deleted_flag");
            entity.Property(e => e.Typegroup)
                .HasMaxLength(255)
                .HasColumnName("typegroup");
            entity.Property(e => e.Typename)
                .HasMaxLength(255)
                .HasColumnName("typename");
            entity.Property(e => e.Typevalue)
                .HasMaxLength(255)
                .HasColumnName("typevalue");
            entity.Property(e => e.Typeevent)
                .HasMaxLength(100)
                .HasColumnName("typeevent");
        }
    }

}
