using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class AdjudicacionConfiguracion : IEntityTypeConfiguration<AdjudicacionEntidad>
{
    public void Configure(EntityTypeBuilder<AdjudicacionEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("Adjudicacion", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
        builder.Property(p => p.CodigoContrato).HasColumnName("CodigoContrato");
        builder.Property(p => p.Especie).HasColumnName("Especie");
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}