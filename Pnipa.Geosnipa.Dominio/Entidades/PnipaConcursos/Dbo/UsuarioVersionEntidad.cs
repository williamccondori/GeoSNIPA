using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class UsuarioVersionEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public bool? Vigente { get; set; }
    }
}
