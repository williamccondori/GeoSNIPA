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

        BsonClassMap.RegisterClassMap<SubProyectoEntidad>(cm =>
        {
            cm.MapIdProperty(c => c.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
            cm.MapMember(c => c.CodigoSubProyecto).SetElementName("codigo_subproyecto");
            cm.MapMember(c => c.Convocatoria).SetElementName("convocatoria");
            cm.MapMember(c => c.Ventanilla).SetElementName("ventanilla");
            cm.MapMember(c => c.InstitucionSuvencionadora).SetElementName("institucion_suvencionadora");
            cm.MapMember(c => c.Ubigeo).SetElementName("ubigeo");
            cm.MapMember(c => c.Longitud).SetElementName("longitud");
            cm.MapMember(c => c.Latitud).SetElementName("latitud");
            cm.MapMember(c => c.SubSector).SetElementName("sub_sector");
            cm.MapMember(c => c.TipoFondo).SetElementName("tipo_fondo");
            cm.MapMember(c => c.TituloSubproyecto).SetElementName("titulo_subproyecto");
            cm.MapMember(c => c.Departamento).SetElementName("departamento");
            cm.MapMember(c => c.Provincia).SetElementName("provincia");
            cm.MapMember(c => c.Distrito).SetElementName("distrito");
            cm.MapMember(c => c.Omr).SetElementName("omr");
            cm.MapMember(c => c.Bonificacion).SetElementName("bonificacion");
            cm.MapMember(c => c.Tema).SetElementName("tema");
            cm.MapMember(c => c.EslabonCadena).SetElementName("eslabon_cadena");
            cm.MapMember(c => c.Especies).SetElementName("especies");
            cm.MapMember(c => c.Usuario).SetElementName("usuario");
            cm.MapMember(c => c.EntidadProponente).SetElementName("entidad_proponente");
            cm.MapMember(c => c.EstadoEjecucion).SetElementName("estado_ejecucion");
            cm.MapMember(c => c.LinkImagenInicial).SetElementName("link_imagen_inicial");
            cm.MapMember(c => c.LinkImagenes).SetElementName("link_imagenes").SetDefaultValue(string.Empty);
            cm.MapMember(c => c.NumeroContrato).SetElementName("numero_contrato");
            cm.MapMember(c => c.AporteEntidadAsociada).SetElementName("aporte_entidad_asociada");
            cm.MapMember(c => c.AporteEntidadColaboradora).SetElementName("aporte_entidad_colaboradora");
            cm.MapMember(c => c.AporteEntidadProponente).SetElementName("aporte_entidad_proponente");
            cm.MapMember(c => c.AportePnipa).SetElementName("aporte_pnipa");
            cm.MapMember(c => c.TotalSubProyecto).SetElementName("total_subproyecto");
            cm.MapMember(c => c.Hito).SetElementName("hito");
            cm.MapMember(c => c.DesenbolsoPnipa).SetElementName("desenbolso_pnipa");
            cm.MapMember(c => c.TipoEntidadParticipa).SetElementName("tipo_entidad_participa");
            cm.MapMember(c => c.BeneficioAmbiental).SetElementName("beneficio_ambiental");
            cm.MapMember(c => c.TemaAmbiental).SetElementName("tema_ambiental");
            cm.MapMember(c => c.BeneficioSocial).SetElementName("beneficio_social");
            cm.MapMember(c => c.NumeroBeneficiariosMujeres).SetElementName("numero_beneficiarios_mujeres");
            cm.MapMember(c => c.NumeroBeneficiariosHombres).SetElementName("numero_beneficiarios_hombres");
            cm.MapMember(c => c.TotalBeneficiarios).SetElementName("total_beneficiarios");
            cm.MapMember(c => c.SubProyectoEmblematico).SetElementName("subproyecto_emblematico");
            cm.MapMember(c => c.LinkFicha).SetElementName("link_ficha");
            cm.MapMember(c => c.HambreCero).SetElementName("hambre_cero");
        });
    }

    public IMongoCollection<SubProyectoEntidad> SubProyectos =>
        _database.GetCollection<SubProyectoEntidad>("sub_proyectos");
}