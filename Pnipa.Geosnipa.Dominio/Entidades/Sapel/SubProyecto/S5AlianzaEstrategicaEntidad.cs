namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class S5AlianzaEstrategicaEntidad
{
    public int AlianzaEstrategicaId { get; set; }
    public int SubProyectoId { get; set; }
    public string? Siglas { get; set; }
    public char AudEstadoRegistro { get; set; }
    public string? TmDetDesctipcionRolConcurso { get; set; }
    public string? TmDetDesctipcionCategoriaActividad { get; set; }
    public string? RazonSocial { get; set; }
}