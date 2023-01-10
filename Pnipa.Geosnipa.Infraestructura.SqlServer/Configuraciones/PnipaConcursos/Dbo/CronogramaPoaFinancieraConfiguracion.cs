using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class CronogramaPoaFinancieraConfiguracion : IEntityTypeConfiguration<CronogramaPoaFinancieraEntidad>
{
    public void Configure(EntityTypeBuilder<CronogramaPoaFinancieraEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("CronogramaPoaFinanciera", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.PoaId).HasColumnName("PoaID").IsRequired();
        builder.Property(p => p.ProyectoId).HasColumnName("ProyectoID").IsRequired();
        builder.Property(p => p.Mes).HasColumnName("Mes").IsRequired();
        builder.Property(p => p.Meta).HasColumnName("Meta").HasPrecision(18, 4);
        builder.Property(p => p.Monto).HasColumnName("Monto").HasPrecision(18, 4);
        builder.Property(p => p.OldId).HasColumnName("OldID");
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}