using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class AporteEntidadPasoCriticoEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int PasoCriticoId { get; set; }
    public int PoaId { get; set; }
    public int EntidadId { get; set; }
    public decimal? AporteMonetario { get; set; }
    public decimal? AporteNoMonetario { get; set; }
    public int? OldId { get; set; }
}