using Microsoft.Extensions.DependencyInjection;
using Pnipa.Geosnipa.Dominio.Repositorios.Geosnipa;
using Pnipa.Geosnipa.Infraestructura.MongoDb.Contextos;
using Pnipa.Geosnipa.Infraestructura.MongoDb.Repositorios;

namespace Pnipa.Geosnipa.Infraestructura.MongoDb;

public static class ServicesExtension
{
    public static void AddInfrastructureMongoDbLayer(this IServiceCollection services)
    {
        services.AddSingleton(new GeosnipaContexto("mongodb://root:ficticio@172.16.24.65:27017/", "geosnipa"));
        services.AddTransient<ISubProyectoRepositorio, SubProyectoRepositorio>();
    }
}