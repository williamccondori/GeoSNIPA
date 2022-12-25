using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones;

public class ConcursoFondoConfiguracion : IEntityTypeConfiguration<ConcursoFondo>
{
    public void Configure(EntityTypeBuilder<ConcursoFondo> builder)
    {
        builder.HasKey(p => new {p.ConcursoFondoId});
        builder.ToTable("CONCURSOFONDO", "CONCURSO");
        builder.Property(p => p.ConcursoFondoId).HasColumnName("CONCURSOFONDO_ID").IsRequired();
        builder.Property(p => p.FondoId).HasColumnName("FONDO_ID").IsRequired();
        builder.Property(p => p.ConcursoId).HasColumnName("CONCURSO_ID").IsRequired();
        builder.Property(p => p.AudEstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}