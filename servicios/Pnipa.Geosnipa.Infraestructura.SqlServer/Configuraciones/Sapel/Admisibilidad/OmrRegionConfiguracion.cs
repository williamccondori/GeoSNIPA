using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Admisibilidad;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Admisibilidad;

public class OmrRegionConfiguracion : IEntityTypeConfiguration<OmrRegionEntidad>
{
    public void Configure(EntityTypeBuilder<OmrRegionEntidad> builder)
    {
        builder.HasKey(p => new { p.OmrRegionId });
        builder.ToTable("OMRREGION", "ADMISIBILIDAD");
        builder.Property(p => p.OmrRegionId).HasColumnName("OMRREGION_ID").IsRequired();
        builder.Property(p => p.OmrId).HasColumnName("OMR_ID");
        builder.Property(p => p.OmrDescription).HasColumnName("OMR_DESCRIPCION");
        builder.Property(p => p.DepartamentoId).HasColumnName("DPTO_ID");
        builder.Property(p => p.DepartamentoNombre).HasColumnName("DPTO_NOMBRE");
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}