using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class SapelUbigeoConfiguracion : IEntityTypeConfiguration<SapelUbigeoEntidad>
{
    public void Configure(EntityTypeBuilder<SapelUbigeoEntidad> builder)
    {
        builder.HasKey(p => new { p.UbigeoId });
        builder.ToTable("SAPEL_UBIGEO", "dbo");
        builder.Property(p => p.UbigeoId).HasColumnName("UBI_ID").IsRequired();
        builder.Property(p => p.DepartamentoId).HasColumnName("DPTO_ID");
        builder.Property(p => p.ProvinciaId).HasColumnName("PROV_ID");
        builder.Property(p => p.DistritoId).HasColumnName("DIST_ID");
        builder.Property(p => p.DepartamentoNombre).HasColumnName("DPTO_NOMBRE");
        builder.Property(p => p.ProvinciaNombre).HasColumnName("PROV_NOMBRE");
        builder.Property(p => p.DistritoNombre).HasColumnName("DIST_NOMBRE");
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}