using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class SapelUbigeoEntidad : EntidadAuditableSapel
{
    public string? UbigeoId { get; set; }
    public string? DepartamentoId { get; set; }
    public string? ProvinciaId { get; set; }
    public string? DistritoId { get; set; }
    public string? DepartamentoNombre { get; set; }
    public string? ProvinciaNombre { get; set; }
    public string? DistritoNombre { get; set; }
}