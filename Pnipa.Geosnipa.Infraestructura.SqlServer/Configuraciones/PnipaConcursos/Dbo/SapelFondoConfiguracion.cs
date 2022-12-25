using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class SapelFondoConfiguracion : IEntityTypeConfiguration<SapelFondoEntidad>
{
    public void Configure(EntityTypeBuilder<SapelFondoEntidad> builder)
    {
        builder.HasKey(p => new {p.FondoId});
        builder.ToTable("SAPEL_FONDO", "dbo");
        builder.Property(p => p.FondoId).HasColumnName("FONDO_ID").IsRequired();
        builder.Property(p => p.TipoFondoId).HasColumnName("TIPOFONDO_ID");
        builder.Property(p => p.TipoFondoNombre).HasColumnName("TIPOFONDO_NOMBRE");
        builder.Property(p => p.TipoSubProyectoSiglas).HasColumnName("TIPOSUBPROYECTO_SIGLAS"); 
        builder.Property(p => p.TipoSubProyectoNombre).HasColumnName("TIPOSUBPROYECTO_NOMBRE");
        builder.Property(p => p.AudEstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}