using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Concurso;

public class ConcursoFondoEntidad : EntidadAuditableSapel
{
    public int ConcursoFondoId { get; set; }
    public int FondoId { get; set; }
    public int ConcursoId { get; set; }
}
