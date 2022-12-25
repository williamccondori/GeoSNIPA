using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel;

public class SubProyectoConfiguracion : IEntityTypeConfiguration<SubProyecto>
{
    public void Configure(EntityTypeBuilder<SubProyecto> builder)
    {
        builder.HasKey(p => new {p.SubProyectoId});
        builder.ToTable("SUBPROYECTO", "SUBPROYECTO");
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID");
        builder.Property(p => p.EntidadId).HasColumnName("ENTIDAD_ID");
        builder.Property(p => p.UsuarioId).HasColumnName("USUARIO_ID");
    }
}