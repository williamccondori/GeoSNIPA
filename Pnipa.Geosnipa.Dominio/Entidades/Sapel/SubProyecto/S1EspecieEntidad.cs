using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class S1EspecieEntidad : EntidadAuditableSapel
{
    public const string TipoEspecieP = "P";

    public int SEspecieId { get; set; }
    public int SubProyectoId { get; set; }
    public int EspecieId { get; set; }
    public string? EspecieNombre { get; set; }
    public string? EspecieOtros { get; set; }
    public string? TipoEspecie { get; set; }
}
