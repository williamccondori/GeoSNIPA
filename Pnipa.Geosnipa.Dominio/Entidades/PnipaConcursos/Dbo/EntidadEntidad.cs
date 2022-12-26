using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class EntidadEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int PostulanteId { get; set; }
        public string? Nombre { get; set; }
    }
}
