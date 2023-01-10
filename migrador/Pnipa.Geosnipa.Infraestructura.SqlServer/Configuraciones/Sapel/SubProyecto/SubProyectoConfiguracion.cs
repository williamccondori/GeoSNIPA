using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.SubProyecto;

public class SubProyectoConfiguracion : IEntityTypeConfiguration<SubProyectoEntidad>
{
    public void Configure(EntityTypeBuilder<SubProyectoEntidad> builder)
    {
        builder.HasKey(p => new { p.SubProyectoId });
        builder.ToTable("SUBPROYECTO", "SUBPROYECTO");
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID");
        builder.Property(p => p.EntidadId).HasColumnName("ENTIDAD_ID");
        builder.Property(p => p.UsuarioId).HasColumnName("USUARIO_ID");
        builder.Property(p => p.ConcursoFondoId).HasColumnName("CONCURSOFONDO_ID");
        builder.Property(p => p.S1Titulo).HasColumnName("S1TITULO");
        builder
            .Property(p => p.S1TmDetalleDescripcionEslabon)
            .HasColumnName("S1TMDET_DESC_ESLABON");
        builder.Property(p => p.S1TmDetalleDescripcionTema).HasColumnName("S1TMDET_DESC_TEMA");
        builder.Property(p => p.EstadoId).HasColumnName("EST_ID");
        builder.Property(p => p.EstadoNombre).HasColumnName("EST_NOMBRE");
        builder.Property(p => p.S1CodigoSubProyecto).HasColumnName("S1CODIGOSUBPROYECTO");
        builder.Property(p => p.SubProyectoIdPadre).HasColumnName("SUBPROYECTO_ID_PADRE");
        builder
            .Property(p => p.S9CantidadAgentesProductivosHombres)
            .HasColumnName("S9CANTAGENTESPRODUCTIVOSHOMBRES");
        builder
            .Property(p => p.S9CantidadAgentesProductivosMujeres)
            .HasColumnName("S9CANTAGENTESPRODUCTIVOSMUJERES");
        builder
            .Property(p => p.S9CantidadAgentesInnovacionHombres)
            .HasColumnName("S9CANTAGENTESINNOVACIONHOMBRES");
        builder
            .Property(p => p.S9CantidadAgentesInnovacionMujeres)
            .HasColumnName("S9CANTAGENTESINNOVACIONMUJERES");
        builder.Property(p => p.TotalAporte).HasColumnName("TOTALAPORTE").HasPrecision(12, 4);
        builder.Property(p => p.AportePnipa).HasColumnName("APORTEPNIPA").HasPrecision(12, 4);
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}