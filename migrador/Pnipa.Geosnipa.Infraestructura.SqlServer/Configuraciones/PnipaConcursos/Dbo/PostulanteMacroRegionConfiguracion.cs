using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class PostulanteMacroRegionConfiguracion
    : IEntityTypeConfiguration<PostulanteMacroRegionEntidad>
{
    public void Configure(EntityTypeBuilder<PostulanteMacroRegionEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("PostulanteMacroRegion", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
        builder.Property(p => p.MacroRegionId).HasColumnName("MacroRegionID");
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}