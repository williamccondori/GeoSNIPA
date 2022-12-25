namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel;

public class ContratoAdjudicacionEntidad
{
    public int ContratoAdjudicacionId { get; set; }
    public string? Nombre { get; set; }
    public string? Comentario { get; set; }
    public DateTime? Fecha { get; set; }
    public string? ComentarioFirmado { get; set; }
    public int SubProyectoId { get; set; }
    public char AudEstadoRegistro { get; set; }
}