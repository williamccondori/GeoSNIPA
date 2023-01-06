using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo
{
    public class PoaConfiguracion : IEntityTypeConfiguration<PoaEntidad>
    {
        public void Configure(EntityTypeBuilder<PoaEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("Poa", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.PoaId).HasColumnName("PoaID").IsRequired();
            builder.Property(p => p.RubroElegibleId).HasColumnName("RubroElegibleID").IsRequired();
            builder.Property(p => p.ProyectoId).HasColumnName("ProyectoID").IsRequired();
            builder.Property(p => p.Tipo).HasColumnName("Tipo");
            builder.Property(p => p.Nombre).HasColumnName("Nombre");
            builder.Property(p => p.UnidadMedida).HasColumnName("UnidadMedidad");
            builder
                .Property(p => p.PrecioUnitario)
                .HasColumnName("PrecioUnitario")
                .HasPrecision(18, 4);
            builder.Property(p => p.MetaFisica).HasColumnName("MetaFisica");
            builder.Property(p => p.Total).HasColumnName("Total").HasPrecision(18, 4);
            builder
                .Property(p => p.MontoPrograma)
                .HasColumnName("MontoPrograma")
                .HasPrecision(18, 4);
            builder.Property(p => p.MontoAlianza).HasColumnName("MontoAlianza").HasPrecision(18, 4);
            builder.Property(p => p.TipoPoaId).HasColumnName("TipoPoaID");
            builder.Property(p => p.OldId).HasColumnName("OldID");
            builder.Property(p => p.UsuarioIdRegistro).HasColumnName("UsuarioIdRegistro");
            builder.Property(p => p.UsuarioIdModifico).HasColumnName("UsuarioIdModifico");
            builder.Property(p => p.FechaRegistro).HasColumnName("FechaRegistro");
            builder.Property(p => p.FechaModifico).HasColumnName("FechaModifico");
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
