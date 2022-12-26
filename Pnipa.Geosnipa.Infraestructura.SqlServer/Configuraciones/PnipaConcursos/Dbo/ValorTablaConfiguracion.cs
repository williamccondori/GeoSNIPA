using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo
{
    public class ValorTablaConfiguracion : IEntityTypeConfiguration<ValorTablaEntidad>
    {
        public void Configure(EntityTypeBuilder<ValorTablaEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("ValoresTabla", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.TablaId).HasColumnName("TablaID").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnName("Descripcion");
            builder.Property(p => p.Valor).HasColumnName("Valor");
            builder.Property(p => p.Orden).HasColumnName("Orden");

            builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
            builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
            builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
            builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
