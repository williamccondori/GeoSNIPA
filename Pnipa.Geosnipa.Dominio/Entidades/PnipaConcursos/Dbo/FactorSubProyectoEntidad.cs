using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class FactorSubProyectoEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int PostulanteId { get; set; }
        public int TemaId { get; set; }
    }
}
