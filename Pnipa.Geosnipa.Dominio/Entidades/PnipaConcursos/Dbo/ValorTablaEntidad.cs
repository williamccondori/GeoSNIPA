using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class ValorTablaEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int TablaId { get; set; }
    public string? Descripcion { get; set; }
    public string? Valor { get; set; }
    public int Orden { get; set; }
}