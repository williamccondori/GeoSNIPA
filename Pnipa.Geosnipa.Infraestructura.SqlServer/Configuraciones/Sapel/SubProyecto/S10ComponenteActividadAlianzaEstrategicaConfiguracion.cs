using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.SubProyecto;

public class S10ComponenteActividadAlianzaEstrategicaConfiguracion
    : IEntityTypeConfiguration<S10ComponenteActividadAlianzaEstrategicaEntidad>
{
    public void Configure(
        EntityTypeBuilder<S10ComponenteActividadAlianzaEstrategicaEntidad> builder
    )
    {
        builder.HasKey(p => new { p.ComponenteActividadAlianzaEstrategicaId });
        builder.ToTable("S10COMPONENTEACTIVIDADALIANZAESTRATEGICA", "SUBPROYECTO");
        builder
            .Property(p => p.ComponenteActividadAlianzaEstrategicaId)
            .HasColumnName("COMPONENTEACTIVIDADALIANZAESTRATEGICA_ID")
            .IsRequired();
        builder
            .Property(p => p.ComponenteActividadId)
            .HasColumnName("COMPONENTEACTIVIDAD_ID")
            .IsRequired();
        builder.Property(p => p.AlianzaEstrategicaId).HasColumnName("ALIANZAESTRATEGICA_ID");
        builder.Property(p => p.Aporte).HasColumnName("APORTE").HasPrecision(12, 4);
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}
