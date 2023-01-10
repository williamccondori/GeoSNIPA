using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class VistaAmbitoIntervencionConfiguracion
    : IEntityTypeConfiguration<VistaAmbitoIntervencionEntidad>
{
    public void Configure(EntityTypeBuilder<VistaAmbitoIntervencionEntidad> builder)
    {
        builder.ToTable("vwAmbitoIntervencion", "dbo");
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID").IsRequired();
        builder.Property(p => p.Numero).HasColumnName("Numero");
        builder.Property(p => p.Distrito).HasColumnName("Distrito");
        builder.Property(p => p.Provincia).HasColumnName("Provincia");
        builder.Property(p => p.Departamento).HasColumnName("Departamento");
        builder.Property(p => p.Ubigeo).HasColumnName("Ubigeo");
        builder.Property(p => p.Latitud).HasColumnName("Latitud");
        builder.Property(p => p.Longitud).HasColumnName("Longitud");
    }
}