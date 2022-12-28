namespace Pnipa.Geosnipa.Dominio.Modelos
{
    public class AporteAlianzaEstrategicaModelo
    {
        public int SubProyectoId { get; set; }
        public string Entidad { get; set; } = default!;
        public decimal MontoAporte { get; set; }

        #region Constantes

        public const string EntidadAsociada = "Entidad Asociada";
        public const string EntidadProponente = "Entidad Proponente";
        public const string EntidadColaboradora = "Entidad Colaboradora";

        #endregion
    }
}
