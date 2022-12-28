using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class SapelFondoEntidad : EntidadAuditableSapel
{
    public int FondoId { get; set; }
    public int TipoFondoId { get; set; }
    public string? TipoFondoNombre { get; set; }
    public string? TipoSubProyectoSiglas { get; set; }
    public string? TipoSubProyectoNombre { get; set; }

    public string SubSector => TipoSubProyectoNombre?.Replace("Subproyectos de ", "") ?? default!;
}
