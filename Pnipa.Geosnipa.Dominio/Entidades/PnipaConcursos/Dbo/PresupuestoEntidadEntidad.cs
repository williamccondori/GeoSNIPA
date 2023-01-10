using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class PresupuestoEntidadEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int? PresupuestoId { get; set; }
    public int? EntidadId { get; set; }
    public decimal? Total { get; set; }
    public decimal? PorcentajeEntidad { get; set; }
    public decimal? AporteMonetario { get; set; }
    public decimal? AporteNoMonetario { get; set; }
    public int? OldId { get; set; }
}