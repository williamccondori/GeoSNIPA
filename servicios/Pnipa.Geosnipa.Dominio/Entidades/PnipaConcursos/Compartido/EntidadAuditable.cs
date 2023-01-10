namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

[Serializable]
public class EntidadAuditable
{
    #region Constantes

    public const string EstadoRegistroActivo = "1";

    #endregion

    public string EstadoRegistro { get; set; } = default!;
    public int? UsuarioIdRegistro { get; set; }
    public int? UsuarioIdModifico { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaModifico { get; set; }
}