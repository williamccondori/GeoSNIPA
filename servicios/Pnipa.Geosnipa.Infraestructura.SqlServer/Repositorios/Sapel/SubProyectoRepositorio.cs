using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;
using Pnipa.Geosnipa.Dominio.Modelos;
using Pnipa.Geosnipa.Dominio.Modelos.Sapel;
using Pnipa.Geosnipa.Dominio.Repositorios.Sapel;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Repositorios.Sapel;

public class SubProyectoRepositorio : ISubProyectoRepositorio
{
    private const string InstitucionSubencionadoraPnipa = "PNIPA";
    private readonly PnipaConcursosContexto _pnipaConcursosContexto;

    private readonly SapelContexto _sapelContexto;

    public SubProyectoRepositorio(
        SapelContexto sapelContexto,
        PnipaConcursosContexto pnipaConcursosContexto
    )
    {
        _sapelContexto = sapelContexto;
        _pnipaConcursosContexto = pnipaConcursosContexto;
    }

    public async Task<IEnumerable<ReporteParaGeoVisorModelo>> ObtenerReporteParaGeoVisor()
    {
        #region Consulta de sub proyectos

        var subProyectos = await (
            from subProyecto in _sapelContexto.SubProyectos
            join concursoFondo in _sapelContexto.ConcursoFondos
                on new { subProyecto.ConcursoFondoId, EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo }
                equals new { concursoFondo.ConcursoFondoId, concursoFondo.EstadoRegistro }
            join contrato in _sapelContexto.Concursos
                on new { concursoFondo.ConcursoId, EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo } equals
                new { contrato.ConcursoId, contrato.EstadoRegistro }
            join contratoAdjudicacion in _sapelContexto.ContratosAdjudicacion
                on new { subProyecto.SubProyectoId, EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo } equals
                new { contratoAdjudicacion.SubProyectoId, contratoAdjudicacion.EstadoRegistro }
            join ubicacion in _sapelContexto.S1Ubicaciones
                on new
                {
                    subProyecto.SubProyectoId,
                    TipoUbicacion = S1UbicacionEntidad.TipoUbicacionP,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new { ubicacion.SubProyectoId, ubicacion.TipoUbicacion, ubicacion.EstadoRegistro }
                into s1UbicacionesLeftJoin
            from ubicacion in s1UbicacionesLeftJoin.DefaultIfEmpty()
            join oficinaMacroRegional in _sapelContexto.OmrRegiones
                on new { ubicacion.DepartamentoId, EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo } equals
                new { oficinaMacroRegional.DepartamentoId, oficinaMacroRegional.EstadoRegistro }
                into oficinaMacroRegionalLeftJoin
            from oficinaMacroRegional in oficinaMacroRegionalLeftJoin.DefaultIfEmpty()
            join alianzaEstrategica in _sapelContexto.AlianzasEstrategicas
                on new
                {
                    subProyecto.SubProyectoId,
                    TmDetDesctipcionRolConcurso = S5AlianzaEstrategicaEntidad.EntidadProponente,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new
                {
                    alianzaEstrategica.SubProyectoId,
                    alianzaEstrategica.TmDetDesctipcionRolConcurso,
                    alianzaEstrategica.EstadoRegistro
                }
                into alianzaEstrategicaLeftJoin
            from alianzaEstrategica in alianzaEstrategicaLeftJoin.DefaultIfEmpty()
            where
                subProyecto.SubProyectoId == subProyecto.SubProyectoIdPadre
                && subProyecto.EstadoId >= 1339
            select new SubProyectoModelo
            {
                SubProyectoId = subProyecto.SubProyectoId,
                FondoId = concursoFondo.FondoId,
                DepartamentoId = ubicacion.DepartamentoId,
                ProvinciaId = ubicacion.ProvinciaId,
                DistritoId = ubicacion.DistritoId,
                S1CodigoSubProyecto = subProyecto.S1CodigoSubProyecto,
                ConcursoNumero = contrato.ConcursoNumero,
                NombreConcurso = contrato.NombreConcurso,
                Longitud = ubicacion.Longitud,
                Latitud = ubicacion.Latitud,
                S1Titulo = subProyecto.S1Titulo,
                OmrId = oficinaMacroRegional.OmrId,
                S1TmDetalleDescripcionTema = subProyecto.S1TmDetalleDescripcionTema,
                S1TmDetalleDescripcionEslabon = subProyecto.S1TmDetalleDescripcionEslabon,
                UsuarioId = subProyecto.UsuarioId,
                RazonSocial = alianzaEstrategica.RazonSocial,
                EstadoNombre = subProyecto.EstadoNombre,
                CodigoContrato = contratoAdjudicacion.Nombre,
                AportePnipa = subProyecto.AportePnipa,
                TotalAporte = subProyecto.TotalAporte,
                TmDetDesctipcionCategoriaActividad =
                    alianzaEstrategica.TmDetDesctipcionCategoriaActividad,
                S9CantidadAgentesProductivosHombres =
                    subProyecto.S9CantidadAgentesProductivosHombres,
                S9CantidadAgentesProductivosMujeres =
                    subProyecto.S9CantidadAgentesProductivosMujeres,
                S9CantidadAgentesInnovacionHombres = subProyecto.S9CantidadAgentesInnovacionHombres,
                S9CantidadAgentesInnovacionMujeres = subProyecto.S9CantidadAgentesInnovacionMujeres
            }
        ).ToListAsync();

        #endregion

        #region Primer filtro (Fondos)

        var fondos = await (
            from fondo in _pnipaConcursosContexto.SapelFondos
            where fondo.EstadoRegistro == EntidadAuditableSapel.EstadoRegistroActivo
            select fondo
        ).ToListAsync();

        #endregion

        #region Segundo filtro (Ubigeos)

        var ubigeos = await (
            from ubigeo in _pnipaConcursosContexto.SapelUbigeos
            where ubigeo.EstadoRegistro == EntidadAuditableSapel.EstadoRegistroActivo
            select ubigeo
        ).ToListAsync();

        #endregion

        #region Tercer filtro (Especies)

        var especies = await (
            from especie in _sapelContexto.Especies
            where
                especie.TipoEspecie == S1EspecieEntidad.TipoEspecieP
                && especie.EstadoRegistro == EntidadAuditableSapel.EstadoRegistroActivo
            group especie by new { especie.SubProyectoId, especie.TipoEspecie }
            into agrupador
            select new EspecieModelo
            {
                SubProyectoId = agrupador.Key.SubProyectoId,
                Nombre = agrupador.Max(grupo => grupo.EspecieNombre)
            }
        ).ToListAsync();

        #endregion

        #region Consulta de aportes

        var aportes = await (
            from alianzaEstrategica in _sapelContexto.AlianzasEstrategicas
            join aporte in _sapelContexto.ComponentesActividadAlianzaEstrategica
                on new
                {
                    alianzaEstrategica.AlianzaEstrategicaId,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new { aporte.AlianzaEstrategicaId, aporte.EstadoRegistro }
            group aporte by new { alianzaEstrategica.SubProyectoId, alianzaEstrategica.TmDetDesctipcionRolConcurso }
            into agrupador
            select new AporteModelo
            {
                SubProyectoId = agrupador.Key.SubProyectoId,
                Entidad = agrupador.Key.TmDetDesctipcionRolConcurso,
                MontoAporte = agrupador.Sum(grupo => grupo.Aporte)
            }
        ).ToListAsync();

        #endregion

        return (
            from subProyecto in subProyectos
            join fondo in fondos on subProyecto.FondoId equals fondo.FondoId
            join ubigeo in ubigeos
                on new { subProyecto.DepartamentoId, subProyecto.ProvinciaId, subProyecto.DistritoId } equals new
                {
                    ubigeo.DepartamentoId,
                    ubigeo.ProvinciaId,
                    ubigeo.DistritoId
                }
                into ubigeoLeftJoin
            from ubigeo in ubigeoLeftJoin.DefaultIfEmpty()
            join especie in especies
                on subProyecto.SubProyectoId equals especie.SubProyectoId
                into especieLeftJoin
            from especie in especieLeftJoin.DefaultIfEmpty()
            select new ReporteParaGeoVisorModelo
            {
                Id = subProyecto.S1CodigoSubProyecto,
                CodigoSubProyecto = ObtenerCodigoSubProyecto(
                    fondo.TipoFondoNombre,
                    fondo.TipoSubProyectoSiglas,
                    subProyecto.S1CodigoSubProyecto
                ),
                Convocatoria = subProyecto.Convocatoria,
                Ventanilla = subProyecto.Ventanilla,
                InstitucionSuvencionadora = InstitucionSubencionadoraPnipa,
                Ubigeo = ubigeo?.UbigeoId,
                Longitud = subProyecto.Longitud,
                Latitud = subProyecto.Latitud,
                SubSector = fondo.SubSector,
                TipoFondo = fondo.TipoFondoNombre,
                TituloSubproyecto = subProyecto.S1Titulo,
                Departamento = ubigeo?.DepartamentoNombre,
                Provincia = ubigeo?.ProvinciaNombre,
                Distrito = ubigeo?.DistritoNombre,
                Omr = ObtenerNombreOficinaMacroRegional(subProyecto.OmrId),
                Bonificacion = 0,
                Tema = subProyecto.S1TmDetalleDescripcionTema,
                EslabonCadena = subProyecto.S1TmDetalleDescripcionEslabon,
                Especies = especie?.Nombre,
                Usuario = subProyecto.UsuarioId.ToString(),
                EntidadProponente = subProyecto.RazonSocial,
                EstadoEjecucion = subProyecto.EstadoNombre,
                NumeroContrato = subProyecto.CodigoContrato,
                AporteEntidadAsociada = ObtenerMontoAporte(
                    aportes,
                    S5AlianzaEstrategicaEntidad.EntidadAsociada,
                    subProyecto.SubProyectoId
                ),
                AporteEntidadColaboradora = ObtenerMontoAporte(
                    aportes,
                    S5AlianzaEstrategicaEntidad.EntidadColaboradora,
                    subProyecto.SubProyectoId
                ),
                AporteEntidadProponente = ObtenerMontoAporte(
                    aportes,
                    S5AlianzaEstrategicaEntidad.EntidadProponente,
                    subProyecto.SubProyectoId
                ),
                AportePnipa = subProyecto.AportePnipa,
                TotalSubProyecto = subProyecto.TotalAporte,
                Hito = "H1",
                DesenbolsoPnipa = decimal.Zero,
                TipoEntidadParticipa = subProyecto.TmDetDesctipcionCategoriaActividad,
                NumeroBeneficiariosMujeres =
                    subProyecto.S9CantidadAgentesProductivosMujeres
                    + subProyecto.S9CantidadAgentesInnovacionMujeres,
                NumeroBeneficiariosHombres =
                    subProyecto.S9CantidadAgentesProductivosHombres
                    + subProyecto.S9CantidadAgentesInnovacionHombres,
                TotalBeneficiarios =
                    subProyecto.S9CantidadAgentesProductivosMujeres
                    + subProyecto.S9CantidadAgentesInnovacionMujeres
                    + subProyecto.S9CantidadAgentesProductivosHombres
                    + subProyecto.S9CantidadAgentesInnovacionHombres,
                SubProyectoEmblematico = "N",
                HambreCero = "N"
            }
        ).ToList();
    }

    #region Métodos estáticos

    private static string ObtenerCodigoSubProyecto(
        string? tipoFondoNombre,
        string? tipoSubProyectoSiglas,
        string? s1CodigoSubProyecto
    )
    {
        return $"{tipoFondoNombre?[..3]}-{tipoSubProyectoSiglas}-{s1CodigoSubProyecto}";
    }

    private static string ObtenerNombreOficinaMacroRegional(int ormId)
    {
        return ormId switch
        {
            1 => "OMR1_PIURA",
            2 => "OMR2_TARAPOTO",
            3 => "OMR3_ANCASH",
            4 => "OMR7_LIMA",
            5 => "OMR4_JUNIN",
            6 => "OMR5_CUSCO",
            7 => "OMR6_AREQUIPA",
            _ => string.Empty
        };
    }

    private static decimal ObtenerMontoAporte(
        IEnumerable<AporteModelo> aportes,
        string entidadAsociada,
        int subProyectoId
    )
    {
        var aporte = aportes.FirstOrDefault(
            p => p.SubProyectoId == subProyectoId && p.Entidad == entidadAsociada
        );
        return aporte?.MontoAporte ?? decimal.Zero;
    }

    #endregion
}