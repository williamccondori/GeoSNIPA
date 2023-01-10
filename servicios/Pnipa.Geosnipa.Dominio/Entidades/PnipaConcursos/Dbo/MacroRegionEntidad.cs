using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class MacroRegionEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
}