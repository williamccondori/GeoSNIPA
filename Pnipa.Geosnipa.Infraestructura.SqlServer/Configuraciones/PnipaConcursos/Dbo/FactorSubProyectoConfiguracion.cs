using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

public class FactorSubProyectoConfiguracion : IEntityTypeConfiguration<FactorSubProyectoEntidad>
{
    public void Configure(EntityTypeBuilder<FactorSubProyectoEntidad> builder)
    {
        builder.HasKey(p => new { p.Id });
        builder.ToTable("FactorSubproyecto", "dbo");
        builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
        builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
        builder.Property(p => p.TemaId).HasColumnName("TemaID");
        builder.Property(p => p.TipoEntidadParticipaId).HasColumnName("TipoEntidadParticipaID");
        builder.Property(p => p.BeneficioAmbientalId).HasColumnName("BeneficioAmbientalID");
        builder.Property(p => p.TemaAmbientalId).HasColumnName("TemaAmbientalID");
        builder.Property(p => p.BeneficioSocialId).HasColumnName("BeneficioSocialID");
        builder.Property(p => p.EspecieId).HasColumnName("EspecieID");
        builder.Property(p => p.EslabonId).HasColumnName("EslabonID");
        builder
            .Property(p => p.NroBeneficiariosHombres)
            .HasColumnName("NroBeneficiariosHombres");
        builder
            .Property(p => p.NroBeneficiariosMujeres)
            .HasColumnName("NroBeneficiariosMujeres");
        builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
        builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
        builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
        builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
        builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
    }
}