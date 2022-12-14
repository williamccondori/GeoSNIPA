using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pnipa.Geosnipa.Dominio.Repositorios.Sapel;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Repositorios.Sapel;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer;

public static class ServicesExtension
{
    public static void AddInfrastructureSqlServerLayer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<SapelContexto>(
            options => options.UseSqlServer(configuration.GetConnectionString("Sapel"))
        );
        services.AddDbContext<PnipaConcursosContexto>(
            options => options.UseSqlServer(configuration.GetConnectionString("PnipaConcursos"))
        );
        services.AddTransient<
            ISubProyectoRepositorio,
            SubProyectoRepositorio
        >();
        services.AddTransient<
            Dominio.Repositorios.PnipaConcursos.ISubProyectoRepositorio,
            Repositorios.PnipaConcursos.SubProyectoRepositorio
        >();
    }
}