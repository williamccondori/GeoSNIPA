using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Repositorios;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Repositorios.Sapel;

public class LecturaRepositorio<T> : ISapelLecturaRepositorio<T> where T : class
{
    private readonly SapelContexto _sapelContexto;

    public LecturaRepositorio(SapelContexto sapelContexto)
    {
        _sapelContexto = sapelContexto;
    }

    public async Task<IEnumerable<T>> ObtenerTodos()
    {
        return await _sapelContexto.Set<T>().ToListAsync();
    }
}
