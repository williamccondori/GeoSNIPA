using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Pnipa.Geosnipa.Aplicacion;

public static class ServicesExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}