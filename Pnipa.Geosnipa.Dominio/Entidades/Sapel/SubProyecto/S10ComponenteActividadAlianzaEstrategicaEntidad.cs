using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class S10ComponenteActividadAlianzaEstrategicaEntidad : EntidadAuditableSapel
{
    public int ComponenteActividadAlianzaEstrategicaId { get; set; }
    public int ComponenteActividadId { get; set; }
    public int AlianzaEstrategicaId { get; set; }
    public decimal Aporte { get; set; }
}