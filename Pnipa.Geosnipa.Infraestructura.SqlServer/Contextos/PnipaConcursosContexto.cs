using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

public class PnipaConcursosContexto : DbContext
{
    public PnipaConcursosContexto(DbContextOptions<PnipaConcursosContexto> options) : base(options)
    { }

    public virtual DbSet<AcreditacionDocumentoGestionEntidad> AcreditacionesDocumentoGestion { get; set; }
    public virtual DbSet<EntidadEntidad> Entidades { get; set; }
    public virtual DbSet<PostulanteEntidad> Postulantes { get; set; }
    public virtual DbSet<PostulanteMacroRegionEntidad> PostulantesMacroRegion { get; set; }
    public virtual DbSet<ProyectoEntidad> Proyectos { get; set; }
    public virtual DbSet<SapelFondoEntidad> SapelFondos { get; set; }
    public virtual DbSet<SapelUbigeoEntidad> SapelUbigeos { get; set; }
    public virtual DbSet<UsuarioEntidad> Usuarios { get; set; }
    public virtual DbSet<ValorTablaEntidad> ValoresTabla { get; set; }
    public virtual DbSet<VistaAmbitoIntervencionEntidad> VistaAmbitosIntervencion { get; set; }
    public virtual DbSet<VistaConvocatoriaEntidad> VistaConvocatorias { get; set; }
    public virtual DbSet<PlanNegocioEntidad> PlanesNegocio { get; set; }
    public virtual DbSet<ProductoPlanNegocioEntidad> ProductosPlanNegocio { get; set; }
    public virtual DbSet<MacroRegionEntidad> MacroRegiones { get; set; }
    public virtual DbSet<EntidadProponenteUbigeoEntidad> EntidadProponenteUbigeos { get; set; }
    public virtual DbSet<FactorSubProyectoEntidad> FactoresSubProyecto { get; set; }
    public virtual DbSet<TemaFactorProyectoCritico> TemasFactorCritico { get; set; }
    public virtual DbSet<PostulanteEjecutorEntidad> PostulanteEjecutores { get; set; }
    public virtual DbSet<AdjudicacionEntidad> Adjudicaciones { get; set; }
    public virtual DbSet<UsuarioVersionEntidad> UsuarioVersiones { get; set; }
    public virtual DbSet<SegProyectoPasoCriticoEntidad> SegProyectoPasosCriticos { get; set; }
    public virtual DbSet<EstadoSubProyectoEntidad> EstadosSubProyecto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AcreditacionDocumentoGestionConfiguracion());
        modelBuilder.ApplyConfiguration(new EntidadConfiguracion());
        modelBuilder.ApplyConfiguration(new PostulanteConfiguracion());
        modelBuilder.ApplyConfiguration(new PostulanteMacroRegionConfiguracion());
        modelBuilder.ApplyConfiguration(new ProyectoConfiguracion());
        modelBuilder.ApplyConfiguration(new SapelFondoConfiguracion());
        modelBuilder.ApplyConfiguration(new SapelUbigeoConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new ValorTablaConfiguracion());
        modelBuilder.ApplyConfiguration(new VistaAmbitoIntervencionConfiguracion());
        modelBuilder.ApplyConfiguration(new VistaConvocatoriaConfiguracion());
        modelBuilder.ApplyConfiguration(new PlanNegocioConfiguracion());
        modelBuilder.ApplyConfiguration(new ProductoPlanNegocioConfiguracion());
        modelBuilder.ApplyConfiguration(new MacroRegionConfiguracion());
        modelBuilder.ApplyConfiguration(new EntidadProponenteUbigeoConfiguracion());
        modelBuilder.ApplyConfiguration(new FactorSubProyectoConfiguracion());
        modelBuilder.ApplyConfiguration(new TemaFactorCriticoConfiguracion());
        modelBuilder.ApplyConfiguration(new PostulanteEjecutorConfiguracion());
        modelBuilder.ApplyConfiguration(new AdjudicacionConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioVersionConfiguracion());
        modelBuilder.ApplyConfiguration(new SegProyectoPasoCriticoConfiguracion());
        modelBuilder.ApplyConfiguration(new EstadoSubProyectoConfiguracion());
    }
}
