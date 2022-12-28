using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo
{
    public class UsuarioVersionConfiguracion : IEntityTypeConfiguration<UsuarioVersionEntidad>
    {
        public void Configure(EntityTypeBuilder<UsuarioVersionEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("UsuarioVersion", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.UsuarioId).HasColumnName("UsuarioID");
            builder.Property(p => p.Vigente).HasColumnName("Vigente");
            builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
            builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
            builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
            builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
