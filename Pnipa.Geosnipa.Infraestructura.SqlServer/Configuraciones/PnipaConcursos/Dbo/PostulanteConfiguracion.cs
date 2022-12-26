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
    public class PostulanteConfiguracion : IEntityTypeConfiguration<PostulanteEntidad>
    {
        public void Configure(EntityTypeBuilder<PostulanteEntidad> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.ToTable("Postulante", "dbo");
            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.EstadoRegistro).HasColumnName("EstadoRegistro").IsRequired();
        }
    }
}
