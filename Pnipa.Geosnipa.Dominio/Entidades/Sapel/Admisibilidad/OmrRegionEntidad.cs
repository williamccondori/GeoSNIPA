namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Admisibilidad;

public class OmrRegionEntidad
{
    public int OmrRegionId { get; set; }
    public int OmrId { get; set; }
    public string? OmrDescription { get; set; }
    public string? DepartamentoId { get; set; }
    public string? DepartamentoNombre { get; set; }
    public char AudEstadoRegistro { get; set; }
}