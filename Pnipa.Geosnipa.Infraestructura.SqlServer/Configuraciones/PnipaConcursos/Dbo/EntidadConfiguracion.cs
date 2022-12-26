using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo
{
    public class EntidadConfiguracion : IEntityTypeConfiguration<EntidadEntidad>
    {
        public void Configure(EntityTypeBuilder<EntidadEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("Entidad", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
            builder.Property(p => p.TipoId).HasColumnName("TipoID");
            builder.Property(p => p.Nombre).HasColumnName("Nombre");

            builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
            builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
            builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
            builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
