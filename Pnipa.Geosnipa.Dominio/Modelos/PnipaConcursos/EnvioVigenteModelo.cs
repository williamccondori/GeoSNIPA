namespace Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos
{
    public class EnvioVigenteModelo
    {
        public int PostulanteId { get; set; }
        public string? CodigoEnvioProyecto { get; set; }
        public bool? Vigente { get; set; }
        public int? EstadoInformeId { get; set; }
        public bool VigenteOk { get; set; }
    }
}
