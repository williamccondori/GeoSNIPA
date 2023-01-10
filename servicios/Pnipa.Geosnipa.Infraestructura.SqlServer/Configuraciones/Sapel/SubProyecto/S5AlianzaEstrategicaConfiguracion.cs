using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.SubProyecto;

public class S5AlianzaEstrategicaConfiguracion
    : IEntityTypeConfiguration<S5AlianzaEstrategicaEntidad>
{
    public void Configure(EntityTypeBuilder<S5AlianzaEstrategicaEntidad> builder)
    {
        builder.HasKey(p => new { p.AlianzaEstrategicaId });
        builder.ToTable("S5ALIANZAESTRATEGICA", "SUBPROYECTO");
        builder
            .Property(p => p.AlianzaEstrategicaId)
            .HasColumnName("ALIANZAESTRATEGICA_ID")
            .IsRequired();
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID");
        builder.Property(p => p.Siglas).HasColumnName("SIGLAS");
        builder
            .Property(p => p.TmDetDesctipcionRolConcurso)
            .HasColumnName("TMDET_DESC_ROLCONCURSO");
        builder
            .Property(p => p.TmDetDesctipcionCategoriaActividad)
            .HasColumnName("TMDET_DESC_CATEGORIAACTIVIDAD");
        builder.Property(p => p.RazonSocial).HasColumnName("RAZONSOCIAL").HasPrecision(300);
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}