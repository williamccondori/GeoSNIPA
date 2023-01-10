using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.PnipaConcursos.Dbo;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

public class PnipaConcursosContexto : DbContext
{
    public PnipaConcursosContexto(DbContextOptions<PnipaConcursosContexto> options) : base(options)
    {
    }

    public virtual DbSet<AcreditacionDocumentoGestionEntidad> AcreditacionesDocumentoGestion { get; set; } = default!;
    public virtual DbSet<EntidadEntidad> Entidades { get; set; } = default!;
    public virtual DbSet<PostulanteEntidad> Postulantes { get; set; } = default!;
    public virtual DbSet<PostulanteMacroRegionEntidad> PostulantesMacroRegion { get; set; } = default!;
    public virtual DbSet<ProyectoEntidad> Proyectos { get; set; } = default!;
    public virtual DbSet<SapelFondoEntidad> SapelFondos { get; set; } = default!;
    public virtual DbSet<SapelUbigeoEntidad> SapelUbigeos { get; set; } = default!;
    public virtual DbSet<UsuarioEntidad> Usuarios { get; set; } = default!;
    public virtual DbSet<ValorTablaEntidad> ValoresTabla { get; set; } = default!;
    public virtual DbSet<VistaAmbitoIntervencionEntidad> VistaAmbitosIntervencion { get; set; } = default!;
    public virtual DbSet<VistaConvocatoriaEntidad> VistaConvocatorias { get; set; } = default!;
    public virtual DbSet<PlanNegocioEntidad> PlanesNegocio { get; set; } = default!;
    public virtual DbSet<ProductoPlanNegocioEntidad> ProductosPlanNegocio { get; set; } = default!;
    public virtual DbSet<MacroRegionEntidad> MacroRegiones { get; set; } = default!;
    public virtual DbSet<EntidadProponenteUbigeoEntidad> EntidadProponenteUbigeos { get; set; } = default!;
    public virtual DbSet<FactorSubProyectoEntidad> FactoresSubProyecto { get; set; } = default!;
    public virtual DbSet<TemaFactorProyectoCritico> TemasFactorCritico { get; set; } = default!;
    public virtual DbSet<PostulanteEjecutorEntidad> PostulanteEjecutores { get; set; } = default!;
    public virtual DbSet<AdjudicacionEntidad> Adjudicaciones { get; set; } = default!;
    public virtual DbSet<UsuarioVersionEntidad> UsuarioVersiones { get; set; } = default!;
    public virtual DbSet<SegProyectoPasoCriticoEntidad> SegProyectoPasosCriticos { get; set; } = default!;
    public virtual DbSet<EstadoSubProyectoEntidad> EstadosSubProyecto { get; set; } = default!;
    public virtual DbSet<AporteEntidadPasoCriticoEntidad> AportesEntidadPasoCritico { get; set; } = default!;
    public virtual DbSet<CronogramaPoaFinancieraEntidad> CronogramasPoaFinanciera { get; set; } = default!;
    public virtual DbSet<PasoCriticoEntidad> PasosCritico { get; set; } = default!;
    public virtual DbSet<PoaEntidad> Poas { get; set; } = default!;
    public virtual DbSet<PresupuestoEntidadEntidad> PresupuestosEntidad { get; set; } = default!;
    public virtual DbSet<PresupuestoEntidad> Presupuestos { get; set; } = default!;

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
        modelBuilder.ApplyConfiguration(new AporteEntidadPasoCriticoConfiguracion());
        modelBuilder.ApplyConfiguration(new CronogramaPoaFinancieraConfiguracion());
        modelBuilder.ApplyConfiguration(new PasoCriticoConfiguracion());
        modelBuilder.ApplyConfiguration(new PoaConfiguracion());
        modelBuilder.ApplyConfiguration(new PresupuestoEntidadConfiguracion());
        modelBuilder.ApplyConfiguration(new PresupuestoConfiguracion());
    }
}