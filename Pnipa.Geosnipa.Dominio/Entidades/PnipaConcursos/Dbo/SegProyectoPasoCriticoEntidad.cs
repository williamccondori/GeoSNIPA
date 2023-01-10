using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class SegProyectoPasoCriticoEntidad : EntidadAuditable
{
    public int SegProyectoPasoCriticoId { get; set; }
    public int PostulanteId { get; set; }
    public int EstadoInformeId { get; set; }
}