using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel;

public class ContratoAdjudicacionConfiguracion : IEntityTypeConfiguration<ContratoAdjudicacion>
{
    public void Configure(EntityTypeBuilder<ContratoAdjudicacion> builder)
    {
        builder.HasKey(p => new {p.ContratoAdjudicacionId});
        builder.ToTable("CONTRATO_ADJUDICACION", "CONTRATO");
        builder.Property(p => p.ContratoAdjudicacionId).HasColumnName("CONTRATOADJUDICACION_ID").IsRequired();
        builder.Property(p => p.Nombre).HasColumnName("NOMBRE");
        builder.Property(p => p.Comentario).HasColumnName("COMENTARIO");
        builder.Property(p => p.Fecha).HasColumnName("FECHA");
        builder.Property(p => p.ComentarioFirmado).HasColumnName("COMENTARIOFIRMADO");
        builder.Property(p => p.SubProyectoId).HasColumnName("SUBPROYECTO_ID").IsRequired();
        builder.Property(p => p.AudEstadoRegistro).HasColumnName("AudEstadoRegistro").IsRequired();
    }
}