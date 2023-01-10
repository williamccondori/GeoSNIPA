namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

[Serializable]
public class EntidadAuditableSapel
{
    #region Constantes

    public const string EstadoRegistroActivo = "1";

    #endregion

    public string EstadoRegistro { get; set; } = default!;
}