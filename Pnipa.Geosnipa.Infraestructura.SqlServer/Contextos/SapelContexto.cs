using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Admisibilidad;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Concurso;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Contrato;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Admisibilidad;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Concurso;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.Contrato;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Configuraciones.Sapel.SubProyecto;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

public class SapelContexto : DbContext
{
    public SapelContexto(DbContextOptions<SapelContexto> options) : base(options)
    {
    }

    public virtual DbSet<OmrRegionEntidad> OmrRegiones { get; set; } = default!;
    public virtual DbSet<ConcursoEntidad> Concursos { get; set; } = default!;
    public virtual DbSet<ConcursoFondoEntidad> ConcursoFondos { get; set; } = default!;
    public virtual DbSet<ContratoAdjudicacionEntidad> ContratosAdjudicacion { get; set; } = default!;

    public virtual DbSet<S10ComponenteActividadAlianzaEstrategicaEntidad> ComponentesActividadAlianzaEstrategica
    {
        get;
        set;
    } = default!;

    public virtual DbSet<S1EspecieEntidad> Especies { get; set; } = default!;
    public virtual DbSet<S1UbicacionEntidad> S1Ubicaciones { get; set; } = default!;
    public virtual DbSet<S5AlianzaEstrategicaEntidad> AlianzasEstrategicas { get; set; } = default!;
    public virtual DbSet<SubProyectoEntidad> SubProyectos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OmrRegionConfiguracion());
        modelBuilder.ApplyConfiguration(new ConcursoConfiguracion());
        modelBuilder.ApplyConfiguration(new ConcursoFondoConfiguracion());
        modelBuilder.ApplyConfiguration(new ContratoAdjudicacionConfiguracion());
        modelBuilder.ApplyConfiguration(new S10ComponenteActividadAlianzaEstrategicaConfiguracion());
        modelBuilder.ApplyConfiguration(new S1EspecieConfiguracion());
        modelBuilder.ApplyConfiguration(new S1UbicacionConfiguracion());
        modelBuilder.ApplyConfiguration(new S5AlianzaEstrategicaConfiguracion());
        modelBuilder.ApplyConfiguration(new SubProyectoConfiguracion());
    }
}