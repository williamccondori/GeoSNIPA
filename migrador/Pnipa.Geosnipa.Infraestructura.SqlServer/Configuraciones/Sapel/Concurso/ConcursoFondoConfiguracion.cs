using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Concurso;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Concurso;

public class ConcursoFondoConfiguracion : IEntityTypeConfiguration<ConcursoFondoEntidad>
{
    public void Configure(EntityTypeBuilder<ConcursoFondoEntidad> builder)
    {
        builder.HasKey(p => new { p.ConcursoFondoId });
        builder.ToTable("CONCURSOFONDO", "CONCURSO");
        builder.Property(p => p.ConcursoFondoId).HasColumnName("CONCURSOFONDO_ID").IsRequired();
        builder.Property(p => p.FondoId).HasColumnName("FONDO_ID").IsRequired();
        builder.Property(p => p.ConcursoId).HasColumnName("CONCURSO_ID").IsRequired();
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}