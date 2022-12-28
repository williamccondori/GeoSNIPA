using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;
using Pnipa.Geosnipa.Dominio.Modelos;
using Pnipa.Geosnipa.Dominio.Modelos.Sapel;
using Pnipa.Geosnipa.Dominio.Repositorios;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Repositorios.Sapel;

public class SubProyectoRepositorio : ISapelSubProyectoRepositorio
{
    private readonly SapelContexto _sapelContexto;
    private readonly PnipaConcursosContexto _pnipaConcursosContexto;

    public SubProyectoRepositorio(
        SapelContexto sapelContexto,
        PnipaConcursosContexto pnipaConcursosContexto
    )
    {
        _sapelContexto = sapelContexto;
        _pnipaConcursosContexto = pnipaConcursosContexto;
    }

    #region Métodos estáticos

    public static string ObtenerCodigoSubProyecto(
        string? tipoFondoNombre,
        string? tipoSubProyectoSiglas,
        string s1CodigoSubProyecto
    )
    {
        return tipoFondoNombre?[..3] + "-" + tipoSubProyectoSiglas + "-" + s1CodigoSubProyecto
            ?? default!;
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

    public static decimal ObtenerMontoAporte(
        List<AporteAlianzaEstrategicaModelo> aportes,
        string entidad,
        int subProyectoId
    )
    {
        var aporte = aportes.FirstOrDefault(
            p => p.SubProyectoId == subProyectoId && p.Entidad == entidad
        );
        return aporte?.MontoAporte ?? decimal.Zero;
    }

    #endregion

    public async Task<IEnumerable<ReporteVisorModelo>> ObtenerReporteParaGeoVisor()
    {
        var fondos = await (
            from fondo in _pnipaConcursosContexto.SapelFondos
            where fondo.EstadoRegistro == EntidadAuditableSapel.EstadoRegistroActivo
            select fondo
        ).ToListAsync();

        var ubigeos = await (
            from ubigeo in _pnipaConcursosContexto.SapelUbigeos
            where ubigeo.EstadoRegistro == EntidadAuditableSapel.EstadoRegistroActivo
            select ubigeo
        ).ToListAsync();

        var especies = await (
            from especie in _sapelContexto.Especies
            where
                especie.TipoEspecie == S1EspecieEntidad.TipoEspecieP
                && especie.EstadoRegistro == EntidadAuditableSapel.EstadoRegistroActivo
            group especie by new { especie.SubProyectoId, especie.TipoEspecie } into agrupador
            select new SubProyectosEspecieModelo
            {
                SubProyectoId = agrupador.Key.SubProyectoId,
                EspecieNombre = agrupador.Max(x => x.EspecieNombre) ?? default!
            }
        ).ToListAsync();

        var aportes = await (
            from alianzaEstrategica in _sapelContexto.AlianzasEstrategicas
            join aporte in _sapelContexto.ComponentesActividadAlianzaEstrategica
                on new
                {
                    alianzaEstrategica.AlianzaEstrategicaId,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new { aporte.AlianzaEstrategicaId, aporte.EstadoRegistro }
            group aporte by new
            {
                alianzaEstrategica.SubProyectoId,
                alianzaEstrategica.TmDetDesctipcionRolConcurso
            } into agrupador
            select new AporteAlianzaEstrategicaModelo
            {
                SubProyectoId = agrupador.Key.SubProyectoId,
                Entidad = agrupador.Key.TmDetDesctipcionRolConcurso,
                MontoAporte = agrupador.Sum(x => x.Aporte)
            }
        ).ToListAsync();

        var subProyectos = await (
            from subProyecto in _sapelContexto.SubProyectos
            join concursoFondo in _sapelContexto.ConcursoFondos
                on new
                {
                    subProyecto.ConcursoFondoId,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new { concursoFondo.ConcursoFondoId, concursoFondo.EstadoRegistro }
            join contrato in _sapelContexto.Concursos
                on new
                {
                    concursoFondo.ConcursoId,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new { contrato.ConcursoId, contrato.EstadoRegistro }
            join contratoAdjudicacion in _sapelContexto.ContratosAdjudicacion
                on new
                {
                    subProyecto.SubProyectoId,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new
                {
                    contratoAdjudicacion.SubProyectoId,
                    contratoAdjudicacion.EstadoRegistro
                }
            join ubicacion in _sapelContexto.S1Ubicaciones
                on new
                {
                    subProyecto.SubProyectoId,
                    TipoUbicacion = S1UbicacionEntidad.TipoUbicacionP,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new
                {
                    ubicacion.SubProyectoId,
                    ubicacion.TipoUbicacion,
                    ubicacion.EstadoRegistro
                }
                into S1UbicacionesLeftJoin
            from ubicacion in S1UbicacionesLeftJoin.DefaultIfEmpty()
            join oficinaMacroRegional in _sapelContexto.OmrRegiones
                on new
                {
                    ubicacion.DepartamentoId,
                    EstadoRegistro = EntidadAuditableSapel.EstadoRegistroActivo
                } equals new
                {
                    oficinaMacroRegional.DepartamentoId,
                    oficinaMacroRegional.EstadoRegistro
                }
                into oficinaMacroRegionalLeftJoin
            from oficinaMacroRegional in oficinaMacroRegionalLeftJoin.DefaultIfEmpty()
            join alianzaEstrategica in _sapelContexto.AlianzasEstrategicas
                on new
                {
                    subProyecto.SubProyectoId,
                    TmDetDesctipcionRolConcurso = "Entidad Proponente",
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
            select new SubProyectosModelo
            {
                SubProyectoId = subProyecto.SubProyectoId,
                FondoId = concursoFondo.FondoId,
                DepartamentoId = ubicacion.DepartamentoId ?? default!,
                ProvinciaId = ubicacion.ProvinciaId ?? default!,
                DistritoId = ubicacion.DistritoId ?? default!,
                S1CodigoSubProyecto = subProyecto.S1CodigoSubProyecto ?? default!,
                ConcursoNumero = contrato.ConcursoNumero ?? default!,
                NombreConcurso = contrato.NombreConcurso ?? default!,
                Longitud = ubicacion.Longitud ?? default!,
                Latitud = ubicacion.Latitud ?? default!,
                S1Titulo = subProyecto.S1Titulo ?? default!,
                OmrId = oficinaMacroRegional.OmrId,
                S1TmDetalleDescripcionTema = subProyecto.S1TmDetalleDescripcionTema ?? default!,
                S1TmDetalleDescripcionEslabon =
                    subProyecto.S1TmDetalleDescripcionEslabon ?? default!,
                UsuarioId = subProyecto.UsuarioId,
                RazonSocial = alianzaEstrategica.RazonSocial ?? default!,
                EstadoNombre = subProyecto.EstadoNombre ?? default!,
                CodigoContrato = contratoAdjudicacion.Nombre ?? default!,
                AportePnipa = subProyecto.AportePnipa,
                TotalAporte = subProyecto.TotalAporte,
                TmDetDesctipcionCategoriaActividad =
                    alianzaEstrategica.TmDetDesctipcionCategoriaActividad ?? default!,
                S9CantidadAgentesProductivosHombres =
                    subProyecto.S9CantidadAgentesProductivosHombres,
                S9CantidadAgentesProductivosMujeres =
                    subProyecto.S9CantidadAgentesProductivosMujeres,
                S9CantidadAgentesInnovacionHombres = subProyecto.S9CantidadAgentesInnovacionHombres,
                S9CantidadAgentesInnovacionMujeres = subProyecto.S9CantidadAgentesInnovacionMujeres
            }
        ).ToListAsync();

        var reporteParaGeoVisor = (
            from subProyecto in subProyectos
            join fondo in fondos on subProyecto.FondoId equals fondo.FondoId
            join ubigeo in ubigeos
                on new
                {
                    subProyecto.DepartamentoId,
                    subProyecto.ProvinciaId,
                    subProyecto.DistritoId
                } equals new
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
            select new ReporteVisorModelo
            {
                S1CodigoSubProyecto = subProyecto.S1CodigoSubProyecto,
                CodigoSubProyecto = ObtenerCodigoSubProyecto(
                    fondo.TipoFondoNombre,
                    fondo.TipoSubProyectoSiglas,
                    subProyecto.S1CodigoSubProyecto
                ),
                Convocatoria = subProyecto.Convocatoria,
                Ventanilla = subProyecto.Ventanilla,
                InstitucionSuvencionadora = ReporteVisorModelo.InstitucionSubencionadoraPnipa,
                Ubigeo = ubigeo?.UbigeoId ?? default!,
                Longitud = subProyecto.Longitud,
                Latitud = subProyecto.Latitud,
                SubSector = fondo.SubSector,
                TipoFondo = fondo.TipoFondoNombre ?? default!,
                TituloSubproyecto = subProyecto.S1Titulo,
                Departamento = ubigeo?.DepartamentoNombre ?? default!,
                Provincia = ubigeo?.ProvinciaNombre ?? default!,
                Distrito = ubigeo?.DistritoNombre ?? default!,
                Omr = ObtenerNombreOficinaMacroRegional(subProyecto.OmrId),
                Bonificacion = decimal.Zero,
                Tema = subProyecto.S1TmDetalleDescripcionTema,
                EslabonCadena = subProyecto.S1TmDetalleDescripcionEslabon,
                Especies = especie?.EspecieNombre ?? default!,
                Usuario = subProyecto.Usuario,
                EntidadProponente = subProyecto.RazonSocial,
                EstadoEjecucion = subProyecto.EstadoNombre,
                LinkImagenes = string.Empty,
                LinkImagenInicial = string.Empty,
                CodigoContrato = subProyecto.CodigoContrato,
                AporteEntidadAsociada = ObtenerMontoAporte(
                    aportes,
                    AporteAlianzaEstrategicaModelo.EntidadAsociada,
                    subProyecto.SubProyectoId
                ),
                AporteEntidadColaboradora = ObtenerMontoAporte(
                    aportes,
                    AporteAlianzaEstrategicaModelo.EntidadColaboradora,
                    subProyecto.SubProyectoId
                ),
                AporteEntidadProponente = ObtenerMontoAporte(
                    aportes,
                    AporteAlianzaEstrategicaModelo.EntidadProponente,
                    subProyecto.SubProyectoId
                ),
                AportePnipa = subProyecto.AportePnipa,
                TotalSubProyecto = subProyecto.TotalAporte,
                Hito = ReporteVisorModelo.PrimerHito,
                DesenbolsoPnipa = decimal.Zero,
                TipoEntidadParticipa = subProyecto.TmDetDesctipcionCategoriaActividad,
                BeneficioAmbiental = string.Empty,
                TemaAmbiental = string.Empty,
                BeneficioSocial = string.Empty,
                NroBeneficiariosMujeres =
                    subProyecto.S9CantidadAgentesProductivosMujeres
                    + subProyecto.S9CantidadAgentesInnovacionMujeres,
                NroBeneficiariosHombres =
                    subProyecto.S9CantidadAgentesProductivosHombres
                    + subProyecto.S9CantidadAgentesInnovacionHombres,
                TotalBeneficiarios =
                    subProyecto.S9CantidadAgentesProductivosMujeres
                    + subProyecto.S9CantidadAgentesInnovacionMujeres
                    + subProyecto.S9CantidadAgentesProductivosHombres
                    + subProyecto.S9CantidadAgentesInnovacionHombres,
                SubProyectoEmblematico = ReporteVisorModelo.NoEsSubProyectoEmblematico,
                LinkFicha = string.Empty,
                HambreCero = ReporteVisorModelo.NoEsSubProyectoHambreCero
            }
        ).ToList();
        return reporteParaGeoVisor;
    }
}
