namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class S1EspecieEntidad
{
    public const string TipoEspecieP = "P";

    public int SEspecieId { get; set; }
    public int SubProyectoId { get; set; }
    public int EspecieId { get; set; }
    public string? EspecieNombre { get; set; }
    public string? EspecieOtros { get; set; }
    public string? TipoEspecie { get; set; }
    public char AudEstadoRegistro { get; set; }
}