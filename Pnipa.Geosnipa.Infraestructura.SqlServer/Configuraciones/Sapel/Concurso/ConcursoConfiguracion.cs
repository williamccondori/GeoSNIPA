using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Concurso;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Concurso;

public class ConcursoConfiguracion : IEntityTypeConfiguration<ConcursoEntidad>
{
    public void Configure(EntityTypeBuilder<ConcursoEntidad> builder)
    {
        builder.HasKey(p => new { p.ConcursoId });
        builder.ToTable("CONCURSO", "CONCURSO");
        builder.Property(p => p.ConcursoId).HasColumnName("CONCURSO_ID").IsRequired();
        builder.Property(p => p.ConvocatoriaId).HasColumnName("CONVOCATORIA_ID").IsRequired();
        builder.Property(p => p.NombreConcurso).HasColumnName("NOMBRECONCURSO");
        builder.Property(p => p.Objetivo).HasColumnName("OBJETIVO");
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
        builder.Property(p => p.ConcursoNumero).HasColumnName("CONCURSO_NUMERO");
    }
}
