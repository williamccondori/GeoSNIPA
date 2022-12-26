using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class ProyectoEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int PostulanteId { get; set; }
    }
}
