using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Concurso;

public class ConcursoEntidad : EntidadAuditableSapel
{
    public int ConcursoId { get; set; }
    public int ConvocatoriaId { get; set; }
    public string? NombreConcurso { get; set; }
    public string? Objetivo { get; set; }
    public string? ConcursoNumero { get; set; }
}