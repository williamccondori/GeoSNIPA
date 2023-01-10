using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class PasoCriticoConfiguracion : IEntityTypeConfiguration<PasoCriticoEntidad>
{
    public void Configure(EntityTypeBuilder<PasoCriticoEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("PasoCritico", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.ProyectoId).HasColumnName("ProyectoID").IsRequired();
        builder.Property(p => p.MesInicio).HasColumnName("MesInicio").IsRequired();
        builder.Property(p => p.MesFin).HasColumnName("MesFin").IsRequired();
        builder.Property(p => p.Numero).HasColumnName("Numero");
        builder.Property(p => p.FechaInicio).HasColumnName("FechaInicio");
        builder.Property(p => p.FechaTermino).HasColumnName("FechaTermino");
        builder.Property(p => p.OldId).HasColumnName("OldID");
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}