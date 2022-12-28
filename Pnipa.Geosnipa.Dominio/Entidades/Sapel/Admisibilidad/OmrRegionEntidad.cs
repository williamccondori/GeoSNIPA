using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Admisibilidad;

public class OmrRegionEntidad : EntidadAuditableSapel
{
    public int OmrRegionId { get; set; }
    public int OmrId { get; set; }
    public string? OmrDescription { get; set; }
    public string? DepartamentoId { get; set; }
    public string? DepartamentoNombre { get; set; }
}
