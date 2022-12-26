namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class SapelFondoEntidad
{
    public int FondoId { get; set; }
    public int TipoFondoId { get; set; }
    public string? TipoFondoNombre { get; set; }
    public string? TipoSubProyectoSiglas { get; set; }
    public string? TipoSubProyectoNombre { get; set; }
    public char AudEstadoRegistro { get; set; }
}
