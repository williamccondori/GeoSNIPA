using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Contrato;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Contrato;

public class ContratoAdjudicacionConfiguracion
    : IEntityTypeConfiguration<ContratoAdjudicacionEntidad>
{
    public void Configure(EntityTypeBuilder<ContratoAdjudicacionEntidad> builder)
    {
        builder.HasKey(p => new { p.ContratoAdjudicacionId });
        builder.ToTable("CONTRATO_ADJUDICACION", "CONTRATO");
        builder
            .Property(p => p.ContratoAdjudicacionId)
            .HasColumnName("CONTRATOADJUDICACION_ID")
            .IsRequired();
        builder.Property(p => p.Nombre).HasColumnName("NOMBRE");
        builder.Property(p => p.Comentario).HasColumnName("COMENTARIO");
        builder.Property(p => p.Fecha).HasColumnName("FECHA");
        builder.Property(p => p.ComentarioFirmado).HasColumnName("COMENTARIOFIRMADO");
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID").IsRequired();
        builder.Property(p => p.EstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}