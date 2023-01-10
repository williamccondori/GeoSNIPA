using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Pnipa.Geosnipa.Dominio.Entidades.Geosnipa;

namespace Pnipa.Geosnipa.Infraestructura.MongoDb.Contextos;

public class GeosnipaContexto : MongoClient
{
    private readonly IMongoDatabase _database;

    public GeosnipaContexto(string cadenaConexion, string nombreBaseDatos)
    {
        var client = new MongoClient(cadenaConexion);

        _database = client.GetDatabase(nombreBaseDatos);

        BsonClassMap.RegisterClassMap<SubProyectoEntidad>(map =>
        {
            map.MapIdProperty(subProyectoEntidad => subProyectoEntidad.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
            map.MapMember(subProyectoEntidad => subProyectoEntidad.CodigoSubProyecto)
                .SetElementName("codigo_subproyecto");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Convocatoria).SetElementName("convocatoria");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Ventanilla).SetElementName("ventanilla");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.InstitucionSuvencionadora)
                .SetElementName("institucion_suvencionadora");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Ubigeo).SetElementName("ubigeo");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Longitud).SetElementName("longitud");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Latitud).SetElementName("latitud");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.SubSector).SetElementName("sub_sector");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.TipoFondo).SetElementName("tipo_fondo");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.TituloSubproyecto)
                .SetElementName("titulo_subproyecto");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Departamento).SetElementName("departamento");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Provincia).SetElementName("provincia");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Distrito).SetElementName("distrito");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Omr).SetElementName("omr");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Bonificacion).SetElementName("bonificacion");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Tema).SetElementName("tema");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.EslabonCadena).SetElementName("eslabon_cadena");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Especies).SetElementName("especies");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Usuario).SetElementName("usuario");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.EntidadProponente)
                .SetElementName("entidad_proponente");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.EstadoEjecucion).SetElementName("estado_ejecucion");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.LinkImagenInicial)
                .SetElementName("link_imagen_inicial");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.LinkImagenes).SetElementName("link_imagenes")
                .SetDefaultValue(string.Empty);
            map.MapMember(subProyectoEntidad => subProyectoEntidad.NumeroContrato).SetElementName("numero_contrato");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.AporteEntidadAsociada)
                .SetElementName("aporte_entidad_asociada");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.AporteEntidadColaboradora)
                .SetElementName("aporte_entidad_colaboradora");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.AporteEntidadProponente)
                .SetElementName("aporte_entidad_proponente");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.AportePnipa).SetElementName("aporte_pnipa");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.TotalSubProyecto)
                .SetElementName("total_subproyecto");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.Hito).SetElementName("hito");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.DesenbolsoPnipa).SetElementName("desenbolso_pnipa");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.TipoEntidadParticipa)
                .SetElementName("tipo_entidad_participa");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.BeneficioAmbiental)
                .SetElementName("beneficio_ambiental");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.TemaAmbiental).SetElementName("tema_ambiental");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.BeneficioSocial).SetElementName("beneficio_social");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.NumeroBeneficiariosMujeres)
                .SetElementName("numero_beneficiarios_mujeres");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.NumeroBeneficiariosHombres)
                .SetElementName("numero_beneficiarios_hombres");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.TotalBeneficiarios)
                .SetElementName("total_beneficiarios");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.SubProyectoEmblematico)
                .SetElementName("subproyecto_emblematico");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.LinkFicha).SetElementName("link_ficha");
            map.MapMember(subProyectoEntidad => subProyectoEntidad.HambreCero).SetElementName("hambre_cero");
        });
    }

    public IMongoCollection<SubProyectoEntidad> SubProyectos =>
        _database.GetCollection<SubProyectoEntidad>("sub_proyectos");
}