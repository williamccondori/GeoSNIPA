using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo
{
    internal class PostulanteMacroRegionConfiguracion : IEntityTypeConfiguration<PostulanteMacroRegionEntidad>
    {
        public void Configure(EntityTypeBuilder<PostulanteMacroRegionEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("PostulanteMacroRegion", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.PostulanteId).HasColumnName("PostulanteID");
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
