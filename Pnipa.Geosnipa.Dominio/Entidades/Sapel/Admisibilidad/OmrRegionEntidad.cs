namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Admisibilidad;

public class OrmRegionEntidad
{
    public int OrmRegionId { get; set; }
    public int? OrmId { get; set; }
    public string? OrmDescription { get; set; }
    public char? DepartamentoId { get; set; }
    public string? DepartamentoNombre { get; set; }
    public char AudEstadoRegistro { get; set; }
}