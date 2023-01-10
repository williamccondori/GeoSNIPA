using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class EntidadProponenteUbigeoConfiguracion
    : IEntityTypeConfiguration<EntidadProponenteUbigeoEntidad>
{
    public void Configure(EntityTypeBuilder<EntidadProponenteUbigeoEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("vwEntidadProponenteUbigeo", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}