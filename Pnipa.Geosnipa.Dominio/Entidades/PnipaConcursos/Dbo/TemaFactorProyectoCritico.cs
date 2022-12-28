using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class TemaFactorProyectoCritico : EntidadAuditable
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
    }
}
