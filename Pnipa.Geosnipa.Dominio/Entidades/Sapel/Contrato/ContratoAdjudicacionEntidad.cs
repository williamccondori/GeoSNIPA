using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Contrato;

public class ContratoAdjudicacionEntidad : EntidadAuditableSapel
{
    public int ContratoAdjudicacionId { get; set; }
    public string? Nombre { get; set; }
    public string? Comentario { get; set; }
    public DateTime Fecha { get; set; }
    public string? ComentarioFirmado { get; set; }
    public int SubProyectoId { get; set; }
}