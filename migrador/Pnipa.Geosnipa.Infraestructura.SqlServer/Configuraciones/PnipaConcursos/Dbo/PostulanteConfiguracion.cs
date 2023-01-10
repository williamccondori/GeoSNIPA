using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class PostulanteConfiguracion : IEntityTypeConfiguration<PostulanteEntidad>
{
    public void Configure(EntityTypeBuilder<PostulanteEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("Postulante", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.EtapaId).HasColumnName("EtapaID");
        builder.Property(p => p.CodigoEnvioProyecto).HasColumnName("CodigoEnvioProyecto");
        builder.Property(p => p.Ventanilla).HasColumnName("ventanilla");
        builder.Property(p => p.UsuarioId).HasColumnName("UsuarioID");
        builder.Property(p => p.ConvocatoriaId).HasColumnName("ConvocatoriaID");
        builder.Property(p => p.LinkImagenInicial).HasColumnName("link_imagen_inicial");
        builder.Property(p => p.LinkImagenes).HasColumnName("link_imagenes");
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}