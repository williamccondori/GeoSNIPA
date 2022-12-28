namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido
{
    public class EntidadAuditableSapel
    {
        public string EstadoRegistro { get; set; } = default!;

        #region Constantes

        public const string EstadoRegistroActivo = "1";

        #endregion
    }
}
