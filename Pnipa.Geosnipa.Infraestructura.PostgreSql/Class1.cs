using NetTopologySuite.Geometries;

namespace Pnipa.Geosnipa.Infraestructura.PostgreSql
{
    public class Class1
    {
        // Propiedad tipo Point
        public Point Punto { get; set; }

        public static Class1 Crear(decimal latitud, decimal longitud)
        {
            var punto = new Point((double)longitud, (double)latitud);
            return new Class1 { Punto = punto };
        }
    }
}
