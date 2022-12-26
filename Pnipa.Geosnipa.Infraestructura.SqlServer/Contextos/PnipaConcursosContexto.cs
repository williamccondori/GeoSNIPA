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
    public virtual DbSet<ValorTablaEntidad> ValoresTabla { get; set; }
    public virtual DbSet<PostulanteEntidad> Postulantes { get; set; }
    public virtual DbSet<PostulanteMacroRegionEntidad> PostulantesMacroRegion { get; set; }
    public virtual DbSet<ProyectoEntidad> Proyectos { get; set; }
    public virtual DbSet<EntidadEntidad> Entidades { get; set; }
    public virtual DbSet<UsuarioEntidad> Usuarios { get; set; }
    public virtual DbSet<AcreditacionDocumentoGestionEntidad> AcreditacionesDocumentoGestion { get; set; }
    public virtual DbSet<VistaAmbitoIntervencionEntidad> VistaAmbitosIntervencion { get; set; }
    public virtual DbSet<VistaConvocatoriaEntidad> VistaConvocatorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SapelFondoConfiguracion());
        modelBuilder.ApplyConfiguration(new SapelUbigeoConfiguracion());
        modelBuilder.ApplyConfiguration(new PostulanteConfiguracion());
        modelBuilder.ApplyConfiguration(new PostulanteMacroRegionConfiguracion());
    }
}