using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Admisibilidad;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Admisibilidad;

public class OrmRegionConfiguracion: IEntityTypeConfiguration<OrmRegionEntidad>
{
    public void Configure(EntityTypeBuilder<OrmRegionEntidad> builder)
    {
        builder.HasKey(p => new {p.om});
        builder.ToTable("CONCURSO", "CONCURSO");
        builder.Property(p => p.ConcursoId).HasColumnName("CONCURSO_ID").IsRequired();
    }
}