using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class UsuarioEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public string? Email { get; set; }
}