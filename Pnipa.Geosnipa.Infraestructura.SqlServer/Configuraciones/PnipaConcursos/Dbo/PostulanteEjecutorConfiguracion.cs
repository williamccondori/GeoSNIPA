using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class PostulanteEjecutorConfiguracion
    : IEntityTypeConfiguration<PostulanteEjecutorEntidad>
{
    public void Configure(EntityTypeBuilder<PostulanteEjecutorEntidad> builder)
    {
        builder.HasKey(p => new { p.PostulanteId });
        builder.ToTable("Postulante_Ejecutora_EsMon", "dbo");
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID").IsRequired();
        builder.Property(p => p.CodigoEnvioProyecto).HasColumnName("CodigoEnvioProyecto");
    }
}