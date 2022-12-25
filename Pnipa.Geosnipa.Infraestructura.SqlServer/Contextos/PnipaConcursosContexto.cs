using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

public class PnipaConcursosContexto : DbContext
{
    public PnipaConcursosContexto(DbContextOptions<PnipaConcursosContexto> options) : base(options)
    {
    }

    public virtual DbSet<SapelFondoEntidad> SapelFondos { get; set; }
    public virtual DbSet<SapelUbigeoEntidad> SapelUbigeos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SapelFondoConfiguracion());
        modelBuilder.ApplyConfiguration(new SapelUbigeoConfiguracion());
    }
}