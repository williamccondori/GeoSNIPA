using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo
{
    public class PresupuestoEntidadConfiguracion
        : IEntityTypeConfiguration<PresupuestoEntidadEntidad>
    {
        public void Configure(EntityTypeBuilder<PresupuestoEntidadEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("PresupuestoEntidad", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.PresupuestoId).HasColumnName("PresupuestoID").IsRequired();
            builder.Property(p => p.EntidadId).HasColumnName("EntidadID").IsRequired();
            builder.Property(p => p.Total).HasColumnName("Total").HasPrecision(18, 4);
            builder
                .Property(p => p.PorcentajeEntidad)
                .HasColumnName("PorcentajeEntidad")
                .HasPrecision(18, 4);
            builder
                .Property(p => p.AporteMonetario)
                .HasColumnName("AporteMonetario")
                .HasPrecision(18, 4);
            builder
                .Property(p => p.AporteNoMonetario)
                .HasColumnName("AporteNoMonetario")
                .HasPrecision(18, 4);
            builder.Property(p => p.OldId).HasColumnName("OldID");
            builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
            builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
            builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
            builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
