using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class PresupuestoConfiguracion : IEntityTypeConfiguration<PresupuestoEntidad>
{
    public void Configure(EntityTypeBuilder<PresupuestoEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("Presupuesto", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
        builder.Property(p => p.Total).HasColumnName("Total").HasPrecision(18, 4);
        builder
            .Property(p => p.MontoPrograma)
            .HasColumnName("MontoPrograma")
            .HasPrecision(18, 4);
        builder
            .Property(p => p.MontoEntidades)
            .HasColumnName("MontoEntidades")
            .HasPrecision(18, 4);
        builder
            .Property(p => p.PorcentajeEntidades)
            .HasColumnName("PorcentajeEntidades")
            .HasPrecision(18, 4);
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}