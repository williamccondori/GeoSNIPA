using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.SubProyecto;

public class S1EspecieConfiguracion: IEntityTypeConfiguration<S1EspecieEntidad>
{
    public void Configure(EntityTypeBuilder<S1EspecieEntidad> builder)
    {
        builder.HasKey(p => new {p.SEspecieId});
        builder.ToTable("S1ESPECIE", "SUBPROYECTO");
        builder.Property(p => p.SEspecieId).HasColumnName("SPESPECIE_ID").IsRequired();
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID").IsRequired();
        builder.Property(p => p.EspecieId).HasColumnName("ESPECIE_ID");
        builder.Property(p => p.EspecieNombre).HasColumnName("ESPECIE_NOMBRE");
        builder.Property(p => p.EspecieOtros).HasColumnName("ESPECIEOTROS");
        builder.Property(p => p.TipoEspecie).HasColumnName("TIPOESPECIE");
        builder.Property(p => p.AudEstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}