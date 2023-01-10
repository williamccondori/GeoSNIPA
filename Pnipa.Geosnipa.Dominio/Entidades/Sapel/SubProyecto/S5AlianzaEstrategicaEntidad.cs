using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class S5AlianzaEstrategicaEntidad : EntidadAuditableSapel
{
    public int AlianzaEstrategicaId { get; set; }
    public int SubProyectoId { get; set; }
    public string? Siglas { get; set; }
    public string? TmDetDesctipcionRolConcurso { get; set; }
    public string? TmDetDesctipcionCategoriaActividad { get; set; }
    public string? RazonSocial { get; set; }

    #region Constantes

    public const string EntidadAsociada = "Entidad Asociada";
    public const string EntidadProponente = "Entidad Proponente";
    public const string EntidadColaboradora = "Entidad Colaboradora";

    #endregion
}