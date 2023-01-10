using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class AdjudicacionEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int PostulanteId { get; set; }
    public string? CodigoContrato { get; set; }
    public string? Especie { get; set; }
}