namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.Ubicaciones.Queries.ObtenerTodasUbicaciones;

public class ObtenerTodasUbicacionesResponse
{
    public IEnumerable<int> Ubicaciones { get; set; }

    public ObtenerTodasUbicacionesResponse()
    {
        Ubicaciones = new List<int>();
    }
}