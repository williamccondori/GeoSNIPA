using Microsoft.EntityFrameworkCore;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    [Keyless]
    public class PostulanteEjecutorEntidad
    {
        public int PostulanteId { get; set; }
        public string? CodigoEnvioProyecto { get; set; }
    }
}
