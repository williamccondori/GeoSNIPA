using Microsoft.EntityFrameworkCore;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

[Keyless]
public class VistaAmbitoIntervencionEntidad
{
    public int PostulanteId { get; set; }
    public long Numero { get; set; }
    public string? Distrito { get; set; }
    public string? Provincia { get; set; }
    public string? Departamento { get; set; }
    public string? Ubigeo { get; set; }
    public string? Latitud { get; set; }
    public string? Longitud { get; set; }
}