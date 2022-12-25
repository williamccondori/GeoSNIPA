using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones;

public class ConcursoConfiguracion : IEntityTypeConfiguration<Concurso>
{
    public void Configure(EntityTypeBuilder<Concurso> builder)
    {
        builder.HasKey(p => new {p.ConcursoId});
        builder.ToTable("CONCURSO", "CONCURSO");
        builder.Property(p => p.ConcursoId).HasColumnName("CONCURSO_ID").IsRequired();
        builder.Property(p => p.ConvocatoriaId).HasColumnName("CONVOCATORIA_ID").IsRequired();
        builder.Property(p => p.NombreConcurso).HasColumnName("NOMBRECONCURSO");
        builder.Property(p => p.Objetivo).HasColumnName("OBJETIVO");
        builder.Property(p => p.AudEstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
        builder.Property(p => p.ConcursoNumero).HasColumnName("CONCURSO_NUMERO");
    }
}