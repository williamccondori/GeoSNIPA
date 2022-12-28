using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;
using Pnipa.Geosnipa.Dominio.Modelos;
using Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos;
using Pnipa.Geosnipa.Dominio.Repositorios;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Repositorios.PnipaConcursos
{
    public class SubProyectoRepositorio : IPnipaConcursosSubProyectoRepositorio
    {
        private readonly PnipaConcursosContexto _pnipaConcursosContexto;

        public SubProyectoRepositorio(PnipaConcursosContexto pnipaConcursosContexto)
        {
            _pnipaConcursosContexto = pnipaConcursosContexto;
        }

        public static string OntenerVentanilla(int codigoVentanilla)
        {
            return codigoVentanilla switch
            {
                1 => "Primera ventanilla",
                2 => "Segunda ventanilla",
                3 => "Tercera ventanilla",
                4 => "Cuarta ventanilla",
                5 => "Quinta ventanilla",
                _ => string.Empty
            };
        }

        public static string ObtenerConvocatoria(string descripcion)
        {
            return descripcion switch
            {
                "Convocatoría 2017 - 2018" => "PNIPA 2017-2018",
                "Convocatoría 2018 - 2019" => "PNIPA 2018-2019",
                _ => "PNIPA 2017-2018"
            };
        }

        public static string ObtenerNombreOficinaMacroRegional(string nombreMacroRegion)
        {
            return nombreMacroRegion switch
            {
                "CA I" => "OMR1_PIURA",
                "CA II" => "OMR2_TARAPOTO",
                "CA III" => "OMR3_ANCASH",
                "CA IV" => "OMR4_JUNIN",
                "CA V" => "OMR5_CUSCO",
                "CA VI" => "OMR6_AREQUIPA",
                "CA VII" => "OMR7_LIMA",
                "CA Sede Central" => "OMR7_LIMA",
                _ => default!
            };
        }

        public static string? ObtenerValorTabla(
            List<ValorTablaEntidad> valoresTabla,
            int? tablaId,
            int? id
        )
        {
            return valoresTabla.FirstOrDefault(x => x.TablaId == tablaId && x.Id == id)?.Valor;
        }

        public async Task<IEnumerable<ReporteVisorModelo>> ObtenerReporteParaGeoVisor()
        {
            var valoresTabla = await (
                from valorTabla in _pnipaConcursosContexto.ValoresTabla
                where valorTabla.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                select valorTabla
            ).ToListAsync();

            var enviosVigentes =
                from postulante in _pnipaConcursosContexto.Postulantes
                join pasoCritico in _pnipaConcursosContexto.SegProyectoPasosCriticos
                    on postulante.Id equals pasoCritico.PostulanteId
                    into pasoCriticoLeftJoin
                from pasoCritico in pasoCriticoLeftJoin.DefaultIfEmpty()
                join usuarioVersion in _pnipaConcursosContexto.UsuarioVersiones
                    on postulante.UsuarioId equals usuarioVersion.UsuarioId
                    into usuarioVersionLeftJoin
                from usuarioVersion in usuarioVersionLeftJoin.DefaultIfEmpty()
                select new EnvioVigenteModelo
                {
                    PostulanteId = postulante.Id,
                    CodigoEnvioProyecto = postulante.CodigoEnvioProyecto,
                    Vigente = usuarioVersion.Vigente,
                    EstadoInformeId = pasoCritico.EstadoInformeId,
                    VigenteOk =
                        (pasoCritico.EstadoInformeId != -1 && usuarioVersion.Vigente == true)
                        || (usuarioVersion.Vigente == null)
                };

            var agrupacionAdjudicaciones =
                from adjudicacion in _pnipaConcursosContexto.Adjudicaciones
                group adjudicacion by new { adjudicacion.PostulanteId } into agrupador
                select new AgrupacionAdjudicacionModelo
                {
                    PostulanteId = agrupador.Key.PostulanteId,
                    AdjudicacionId = agrupador.Max(x => x.Id)
                };

            var categoriasSubProyecto = (
                from estadoSubProyecto in _pnipaConcursosContexto.EstadosSubProyecto
                where
                    estadoSubProyecto.IndicadorSapel
                        == EstadoSubProyectoEntidad.NoEsSubProyectoSapel
                    && estadoSubProyecto.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                select new CategoriaSubProyectoModelo
                {
                    CategoriaSubProyectoId = estadoSubProyecto.CategoriaSubProyectoId ?? 0,
                    PostulanteId = estadoSubProyecto.PostulanteId,
                }
            ).Union(
                from postulante in _pnipaConcursosContexto.Postulantes
                join convocatoria in _pnipaConcursosContexto.VistaConvocatorias
                    on new { Id = postulante.ConvocatoriaId, TipoFondoId = 3 } equals new
                    {
                        convocatoria.Id,
                        convocatoria.TipoFondoId
                    }
                where postulante.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                select new CategoriaSubProyectoModelo
                {
                    CategoriaSubProyectoId = 16,
                    PostulanteId = postulante.Id
                }
            );

            var

            var postulantesInicio = (
                from postulante in _pnipaConcursosContexto.Postulantes
                join envioVigente in enviosVigentes
                    on postulante.Id equals envioVigente.PostulanteId
                join postulanteMacroRegion in _pnipaConcursosContexto.PostulantesMacroRegion
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new
                    {
                        postulanteMacroRegion.PostulanteId,
                        postulanteMacroRegion.EstadoRegistro
                    }
                join acreditacionDocumentoGestion in _pnipaConcursosContexto.AcreditacionesDocumentoGestion
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new
                    {
                        acreditacionDocumentoGestion.PostulanteId,
                        acreditacionDocumentoGestion.EstadoRegistro
                    }
                join convocatoria in _pnipaConcursosContexto.VistaConvocatorias
                    on new
                    {
                        Id = postulante.ConvocatoriaId,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { convocatoria.Id, convocatoria.EstadoRegistro }
                join proyecto in _pnipaConcursosContexto.Proyectos
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { proyecto.PostulanteId, proyecto.EstadoRegistro }
                join categoriaSubProyecto in categoriasSubProyecto
                    on postulante.Id equals categoriaSubProyecto.PostulanteId
                join entidad in _pnipaConcursosContexto.Entidades
                    on new
                    {
                        PostulanteId = postulante.Id,
                        TipoId = 20,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new
                    {
                        entidad.PostulanteId,
                        entidad.TipoId,
                        entidad.EstadoRegistro
                    }
                join adjudicacion in _pnipaConcursosContexto.Adjudicaciones
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { adjudicacion.PostulanteId, adjudicacion.EstadoRegistro }
                    into adjudicacionLeftJoin
                from adjudicacion in adjudicacionLeftJoin.DefaultIfEmpty()
                join ambitoIntervencion in _pnipaConcursosContexto.VistaAmbitosIntervencion
                    on new { PostulanteId = postulante.Id, Numero = (long)decimal.One } equals new
                    {
                        ambitoIntervencion.PostulanteId,
                        ambitoIntervencion.Numero
                    }
                join planNegocio in _pnipaConcursosContexto.PlanesNegocio
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { planNegocio.PostulanteId, planNegocio.EstadoRegistro }
                    into planNegocioLeftJoin
                from planNegocio in planNegocioLeftJoin.DefaultIfEmpty()
                join productoPlanNegocio in _pnipaConcursosContexto.ProductosPlanNegocio
                    on new
                    {
                        PlanNegocioId = planNegocio.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new
                    {
                        productoPlanNegocio.PlanNegocioId,
                        productoPlanNegocio.EstadoRegistro
                    }
                    into productoPlanNegocioLeftJoin
                from productoPlanNegocio in productoPlanNegocioLeftJoin.DefaultIfEmpty()
                join usuario in _pnipaConcursosContexto.Usuarios
                    on new
                    {
                        Id = postulante.UsuarioId,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { usuario.Id, usuario.EstadoRegistro }
                join agrupacionAdjudicacion in agrupacionAdjudicaciones
                    on adjudicacion.Id equals agrupacionAdjudicacion.AdjudicacionId
                join ubigeo in _pnipaConcursosContexto.EntidadProponenteUbigeos
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { ubigeo.PostulanteId, ubigeo.EstadoRegistro }
                    into ubigeoLeftJoin
                from ubigeo in ubigeoLeftJoin.DefaultIfEmpty()
                join ejecutor in _pnipaConcursosContexto.PostulanteEjecutores
                    on postulante.Id equals ejecutor.PostulanteId
                    into ejecutorJoin
                from ejecutor in ejecutorJoin.DefaultIfEmpty()
                join postulanteRegion in _pnipaConcursosContexto.PostulantesMacroRegion
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { postulanteRegion.PostulanteId, postulanteRegion.EstadoRegistro }
                    into postulanteRegionLeftJoin
                from postulanteRegion in postulanteRegionLeftJoin.DefaultIfEmpty()
                join macroRegion in _pnipaConcursosContexto.MacroRegiones
                    on new
                    {
                        Id = postulanteRegion.MacroRegionId,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { macroRegion.Id, macroRegion.EstadoRegistro }
                    into macroRegionLeftJoin
                from macroRegion in macroRegionLeftJoin.DefaultIfEmpty()
                join factor in _pnipaConcursosContexto.FactoresSubProyecto
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { factor.PostulanteId, factor.EstadoRegistro }
                    into factorLeftJoin
                from factor in factorLeftJoin.DefaultIfEmpty()
                join temaFactorCritico in _pnipaConcursosContexto.TemasFactorCritico
                    on factor.TemaId equals temaFactorCritico.Id
                    into temaFactorCriticoLeftJoin
                from temaFactorCritico in temaFactorCriticoLeftJoin.DefaultIfEmpty()
                where
                    postulante.EtapaId > 9
                    && postulante.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                select new SubProyectosModelo
                {
                    PostulanteId = postulante.Id,
                    ProyectoId = proyecto.Id,
                    CodigoSubProyecto = postulante.CodigoEnvioProyecto ?? default!,
                    Convocatoria = ObtenerConvocatoria(convocatoria.Descripcion ?? default!),
                    Ventanilla = OntenerVentanilla(postulante.Ventanilla),
                    InstitucionSuvencionadora = ReporteVisorModelo.InstitucionSubencionadoraPnipa,
                    Ubigeo = ambitoIntervencion.Ubigeo ?? default!,
                    Longitud = ambitoIntervencion.Longitud ?? default!,
                    Latitud = ambitoIntervencion.Latitud ?? default!,
                    SubSector = convocatoria.Fondo ?? default!,
                    TipoFondo = convocatoria.TipoFondo ?? default!,
                    TituloSubProyecto = proyecto.Titulo ?? default!,
                    Departamento = ambitoIntervencion.Departamento ?? default!,
                    Provincia = ambitoIntervencion.Provincia ?? default!,
                    Distrito = ambitoIntervencion.Distrito ?? default!,
                    Omr = ObtenerNombreOficinaMacroRegional(macroRegion.Nombre ?? default!),
                    Bonificacion = decimal.Zero,
                    Tema =
                        temaFactorCritico.Descripcion ?? (productoPlanNegocio.Nombre ?? default!),
                    Usuario = usuario.Email ?? default!,
                    EntidadProponente = entidad.Nombre ?? default!,
                    EstadoEjecucion = proyecto.EstadoEjecucion,
                    LinkImagenInicial = postulante.LinkImagenInicial ?? string.Empty,
                    LinkImagenes = postulante.LinkImagenes ?? string.Empty,
                    NumeroContrato = adjudicacion.CodigoContrato ?? default!,
                    Codigo = convocatoria.Codigo ?? default!,
                    Especie =
                        ObtenerValorTabla(valoresTabla, 52, factor.EspecieId)
                        ?? adjudicacion.Especie
                        ?? default!,
                    VigenteOk = envioVigente.VigenteOk,
                    TipoEntidadParticipa =
                        ObtenerValorTabla(valoresTabla, 59, factor.TipoEntidadParticipaId)
                        ?? default!,
                    BeneficioAmbiental =
                        ObtenerValorTabla(valoresTabla, 60, factor.BeneficioAmbientalId)
                        ?? default!,
                    TemaAmbiental =
                        ObtenerValorTabla(valoresTabla, 61, factor.TemaAmbientalId) ?? default!,
                    BeneficioSocial =
                        ObtenerValorTabla(valoresTabla, 72, factor.BeneficioSocialId) ?? default!,
                    Eslabon = ObtenerValorTabla(valoresTabla, 53, factor.EslabonId) ?? default!,
                    NumeroBeneficiariosHombres = factor.NroBeneficiariosHombres,
                    NumeroBeneficiariosMujeres = factor.NroBeneficiariosMujeres,
                    TotalBeneficiarios = factor.TotalBeneficiarios,
                    IdEmblematico = string.Empty,
                    LinkFicha = string.Empty,
                    HambreCero = null,
                }
            ).Distinct();

            return default!;
        }
    }
}
