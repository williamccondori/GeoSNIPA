using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class VistaConvocatoriaEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int FondoId { get; set; }
    public string? Fondo { get; set; }
    public string? TipoFondo { get; set; }
    public int TipoFondoId { get; set; }
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
}