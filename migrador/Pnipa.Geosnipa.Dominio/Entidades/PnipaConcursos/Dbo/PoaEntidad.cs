using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class PoaEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int? PoaId { get; set; }
    public int? RubroElegibleId { get; set; }
    public int? ProyectoId { get; set; }
    public string? Tipo { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? UnidadMedida { get; set; }
    public decimal? PrecioUnitario { get; set; }
    public int? MetaFisica { get; set; }
    public decimal? Total { get; set; }
    public decimal? MontoPrograma { get; set; }
    public decimal? MontoAlianza { get; set; }
    public int? TipoPoaId { get; set; }
    public int? OldId { get; set; }
}