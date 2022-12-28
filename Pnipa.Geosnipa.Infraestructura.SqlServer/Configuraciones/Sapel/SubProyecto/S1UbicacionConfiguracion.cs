using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.SubProyecto;

public class S1UbicacionConfiguracion : IEntityTypeConfiguration<S1UbicacionEntidad>
{
    public void Configure(EntityTypeBuilder<S1UbicacionEntidad> builder)
    {
        builder.HasKey(p => new { p.UbicacionId });
        builder.ToTable("S1UBICACION", "SUBPROYECTO");
        builder.Property(p => p.UbicacionId).HasColumnName("UBICACION_ID").IsRequired();
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID").IsRequired();
        builder.Property(p => p.TipoUbicacion).HasColumnName("TIPOUBICACION");
        builder.Property(p => p.DepartamentoId).HasColumnName("DPTO_ID");
        builder.Property(p => p.ProvinciaId).HasColumnName("PROV_ID");
        builder.Property(p => p.DistritoId).HasColumnName("DIST_ID");
        builder.Property(p => p.NombreCompleto).HasColumnName("UBI_NOMBRECOMPLETO");
        builder.Property(p => p.Latitud).HasColumnName("LATITUD");
        builder.Property(p => p.Longitud).HasColumnName("LONGITUD");
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}
