using MongoDB.Driver;
using Pnipa.Geosnipa.Dominio.Entidades.Geosnipa;
using Pnipa.Geosnipa.Dominio.Repositorios.Geosnipa;
using Pnipa.Geosnipa.Infraestructura.MongoDb.Contextos;

namespace Pnipa.Geosnipa.Infraestructura.MongoDb.Repositorios;

public class SubProyectoRepositorio : ISubProyectoRepositorio
{
    private readonly GeosnipaContexto _geosnipaContexto;

    public SubProyectoRepositorio(GeosnipaContexto geosnipaContexto)
    {
        _geosnipaContexto = geosnipaContexto;
    }

    public async Task<IEnumerable<SubProyectoEntidad>> ObtenerTodos()
    {
        var resultado = await _geosnipaContexto.SubProyectos.FindAsync(subProyectoEntidad => true);
        return await resultado.ToListAsync();
    }

    public async Task CrearVarios(IEnumerable<SubProyectoEntidad> subProyectos)
    {
        await _geosnipaContexto.SubProyectos.InsertManyAsync(subProyectos);
    }

    public async Task EliminarTodos()
    {
        await _geosnipaContexto.SubProyectos.DeleteManyAsync(subProyectoEntidad => true);
    }
}