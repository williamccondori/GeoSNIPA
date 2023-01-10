using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;
using Pnipa.Geosnipa.Dominio.Modelos;
using Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos;
using Pnipa.Geosnipa.Dominio.Repositorios.PnipaConcursos;
using Pnipa.Geosnipa.Infraestructura.SqlServer.Contextos;

namespace Pnipa.Geosnipa.Infraestructura.SqlServer.Repositorios.PnipaConcursos;

public class SubProyectoRepositorio : ISubProyectoRepositorio
{
    private const string InstitucionSubencionadoraPnipa = "PNIPA";

    private readonly PnipaConcursosContexto _pnipaConcursosContexto;

    public SubProyectoRepositorio(PnipaConcursosContexto pnipaConcursosContexto)
    {
        _pnipaConcursosContexto = pnipaConcursosContexto;
    }

    public async Task<IEnumerable<ReporteParaGeoVisorModelo>> ObtenerReporteParaGeoVisor()
    {
        #region Consulta de categorías para los sub proyectos

        var categorias = (
            from estadoSubProyecto in _pnipaConcursosContexto.EstadosSubProyecto
            where
                estadoSubProyecto.IndicadorSapel
                == EstadoSubProyectoEntidad.NoEsSubProyectoSapel
                && estadoSubProyecto.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
            select new CategoriaModelo
            {
                CategoriaSubProyectoId = estadoSubProyecto.CategoriaSubProyectoId ?? 0,
                PostulanteId = estadoSubProyecto.PostulanteId
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
            select new CategoriaModelo { CategoriaSubProyectoId = 16, PostulanteId = postulante.Id }
        );

        #endregion

        #region Consulta de adjudicaciones para los sub proyectos

        var adjudicaciones =
            from adjudicacion in _pnipaConcursosContexto.Adjudicaciones
            group adjudicacion by new { adjudicacion.PostulanteId }
            into agrupador
            select new AdjudicacionModelo
            {
                PostulanteId = agrupador.Key.PostulanteId,
                AdjudicacionId = agrupador.Max(grupo => grupo.Id)
            };

        #endregion

        #region Consulta de sub proyectos

        var subProyectosConsulta = (
            from postulante in _pnipaConcursosContexto.Postulantes
            join categoria in categorias on postulante.Id equals categoria.PostulanteId
            join postulanteMacroRegion in _pnipaConcursosContexto.PostulantesMacroRegion
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { postulanteMacroRegion.PostulanteId, postulanteMacroRegion.EstadoRegistro }
            join acreditacionDocumentoGestion in _pnipaConcursosContexto.AcreditacionesDocumentoGestion
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { acreditacionDocumentoGestion.PostulanteId, acreditacionDocumentoGestion.EstadoRegistro }
            join convocatoria in _pnipaConcursosContexto.VistaConvocatorias
                on new { Id = postulante.ConvocatoriaId, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { convocatoria.Id, convocatoria.EstadoRegistro }
            join proyecto in _pnipaConcursosContexto.Proyectos
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { proyecto.PostulanteId, proyecto.EstadoRegistro }
            join entidad in _pnipaConcursosContexto.Entidades
                on new
                {
                    PostulanteId = postulante.Id,
                    TipoId = 20,
                    EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                } equals new { entidad.PostulanteId, entidad.TipoId, entidad.EstadoRegistro }
            join adjudicacion in _pnipaConcursosContexto.Adjudicaciones
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { adjudicacion.PostulanteId, adjudicacion.EstadoRegistro }
                into adjudicacionLeftJoin
            from adjudicacion in adjudicacionLeftJoin.DefaultIfEmpty()
            join ambitoIntervencion in _pnipaConcursosContexto.VistaAmbitosIntervencion
                on new { PostulanteId = postulante.Id, Numero = (long)1 } equals new
                {
                    ambitoIntervencion.PostulanteId,
                    ambitoIntervencion.Numero
                }
            join planNegocio in _pnipaConcursosContexto.PlanesNegocio
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { planNegocio.PostulanteId, planNegocio.EstadoRegistro }
                into planNegocioLeftJoin
            from planNegocio in planNegocioLeftJoin.DefaultIfEmpty()
            join productoPlanNegocio in _pnipaConcursosContexto.ProductosPlanNegocio
                on new { PlanNegocioId = planNegocio.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { productoPlanNegocio.PlanNegocioId, productoPlanNegocio.EstadoRegistro }
                into productoPlanNegocioLeftJoin
            from productoPlanNegocio in productoPlanNegocioLeftJoin.DefaultIfEmpty()
            join usuario in _pnipaConcursosContexto.Usuarios
                on new { Id = postulante.UsuarioId, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals new
                {
                    usuario.Id,
                    usuario.EstadoRegistro
                }
            join agrupacionAdjudicacion in adjudicaciones
                on adjudicacion.Id equals agrupacionAdjudicacion.AdjudicacionId
            join ubigeo in _pnipaConcursosContexto.EntidadProponenteUbigeos
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { ubigeo.PostulanteId, ubigeo.EstadoRegistro }
                into ubigeoLeftJoin
            from ubigeo in ubigeoLeftJoin.DefaultIfEmpty()
            join ejecutor in _pnipaConcursosContexto.PostulanteEjecutores
                on postulante.Id equals ejecutor.PostulanteId
                into ejecutorJoin
            from ejecutor in ejecutorJoin.DefaultIfEmpty()
            join postulanteRegion in _pnipaConcursosContexto.PostulantesMacroRegion
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { postulanteRegion.PostulanteId, postulanteRegion.EstadoRegistro }
                into postulanteRegionLeftJoin
            from postulanteRegion in postulanteRegionLeftJoin.DefaultIfEmpty()
            join macroRegion in _pnipaConcursosContexto.MacroRegiones
                on new { Id = postulanteRegion.MacroRegionId, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo }
                equals new { macroRegion.Id, macroRegion.EstadoRegistro }
                into macroRegionLeftJoin
            from macroRegion in macroRegionLeftJoin.DefaultIfEmpty()
            join factor in _pnipaConcursosContexto.FactoresSubProyecto
                on new { PostulanteId = postulante.Id, EstadoRegistro = EntidadAuditable.EstadoRegistroActivo } equals
                new { factor.PostulanteId, factor.EstadoRegistro }
                into factorLeftJoin
            from factor in factorLeftJoin.DefaultIfEmpty()
            join temaFactorCritico in _pnipaConcursosContexto.TemasFactorCritico
                on factor.TemaId equals temaFactorCritico.Id
                into temaFactorCriticoLeftJoin
            from temaFactorCritico in temaFactorCriticoLeftJoin.DefaultIfEmpty()
            where
                postulante.EtapaId > 9
                && postulante.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
            select new SubProyectoModelo
            {
                PostulanteId = postulante.Id,
                ProyectoId = proyecto.Id,
                CodigoSubProyecto = postulante.CodigoEnvioProyecto,
                Convocatoria = ObtenerConvocatoria(convocatoria.Descripcion),
                Ventanilla = OntenerVentanilla(postulante.Ventanilla),
                InstitucionSuvencionadora = InstitucionSubencionadoraPnipa,
                Ubigeo = ambitoIntervencion.Ubigeo,
                Longitud = ambitoIntervencion.Longitud,
                Latitud = ambitoIntervencion.Latitud,
                SubSector = convocatoria.Fondo,
                TipoFondo = convocatoria.TipoFondo,
                Titulo = proyecto.Titulo,
                Departamento = ambitoIntervencion.Departamento,
                Provincia = ambitoIntervencion.Provincia,
                Distrito = ambitoIntervencion.Distrito,
                Omr = ObtenerNombreOficinaMacroRegional(macroRegion.Nombre),
                Bonificacion = decimal.Zero,
                Tema = temaFactorCritico.Descripcion ?? productoPlanNegocio.Nombre,
                Usuario = usuario.Email,
                EntidadProponente = entidad.Nombre,
                FechaInicioReal = proyecto.FechaInicioReal,
                LinkImagenInicial = postulante.LinkImagenInicial,
                LinkImagenes = postulante.LinkImagenes,
                CodigoContrato = adjudicacion.CodigoContrato,
                Codigo = convocatoria.Codigo,
                EspecieId = factor.EspecieId,
                TipoEntidadParticipaId = factor.TipoEntidadParticipaId,
                BeneficioAmbientalId = factor.BeneficioAmbientalId,
                TemaAmbientalId = factor.TemaAmbientalId,
                BeneficioSocialId = factor.BeneficioSocialId,
                EslabonId = factor.EslabonId,
                NumeroBeneficiariosHombres = factor.NroBeneficiariosHombres,
                NumeroBeneficiariosMujeres = factor.NroBeneficiariosMujeres,
                TotalBeneficiarios =
                    factor.NroBeneficiariosHombres + factor.NroBeneficiariosMujeres,
                Especie = adjudicacion.Especie
            }
        ).Distinct();

        var subProyectos = await subProyectosConsulta.ToListAsync();

        #endregion

        #region Primer filtro (Vigencias)

        var vigencias = await (
            from postulante in _pnipaConcursosContexto.Postulantes
            join pasoCritico in _pnipaConcursosContexto.SegProyectoPasosCriticos
                on postulante.Id equals pasoCritico.PostulanteId
                into pasoCriticoLeftJoin
            from pasoCritico in pasoCriticoLeftJoin.DefaultIfEmpty()
            join usuarioVersion in _pnipaConcursosContexto.UsuarioVersiones
                on postulante.UsuarioId equals usuarioVersion.UsuarioId
                into usuarioVersionLeftJoin
            from usuarioVersion in usuarioVersionLeftJoin.DefaultIfEmpty()
            select new VigenciaModelo
            {
                PostulanteId = postulante.Id,
                CodigoEnvioProyecto = postulante.CodigoEnvioProyecto,
                Vigente = usuarioVersion.Vigente,
                EstadoInforme = pasoCritico.EstadoInformeId,
                VigenteOk =
                    (
                        ((int?)pasoCritico.EstadoInformeId ?? -1) != -1
                        && usuarioVersion.Vigente == true
                    )
                    || usuarioVersion.Vigente == null
            }
        ).ToListAsync();

        #endregion

        #region Segundo filtro

        #endregion

        #region Cuarto filtro (Aportes)

        var aportes = await (
            from postulante in _pnipaConcursosContexto.Postulantes
            join entidad in _pnipaConcursosContexto.Entidades
                on postulante.Id equals entidad.PostulanteId
            join presupuestoEntidad in _pnipaConcursosContexto.PresupuestosEntidad
                on entidad.Id equals presupuestoEntidad.EntidadId
            where
                entidad.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                && presupuestoEntidad.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
            group new { postulante, entidad, presupuestoEntidad } by new { postulante.Id }
            into agrupador
            select new AportesModelo
            {
                PostulanteId = agrupador.Key.Id,
                TotalSubProyecto = _pnipaConcursosContexto.Presupuestos
                    .Where(
                        presupuesto =>
                            presupuesto.PostulanteId == agrupador.Key.Id
                            && presupuesto.EstadoRegistro
                            == EntidadAuditable.EstadoRegistroActivo
                    )
                    .Sum(presupuesto => presupuesto.Total),
                AportePnipa = _pnipaConcursosContexto.Presupuestos
                    .Where(
                        presupuesto =>
                            presupuesto.PostulanteId == agrupador.Key.Id
                            && presupuesto.EstadoRegistro
                            == EntidadAuditable.EstadoRegistroActivo
                    )
                    .Sum(presupuesto => presupuesto.MontoPrograma),
                AporteEntidadProponente = agrupador.Sum(
                    grupo =>
                        grupo.entidad.TipoId == 20
                            ? grupo.presupuestoEntidad.AporteMonetario
                            : decimal.Zero
                ),
                AporteEntidadAsociada = agrupador.Sum(
                    grupo =>
                        grupo.entidad.TipoId == 21
                            ? grupo.presupuestoEntidad.AporteMonetario
                            : decimal.Zero
                ),
                AporteEntidadColaboradora = agrupador.Sum(
                    grupo =>
                        grupo.entidad.TipoId == 98
                            ? grupo.presupuestoEntidad.AporteMonetario
                            : decimal.Zero
                )
            }
        ).ToListAsync();

        #endregion

        #region Quinto filtro (Desembolsos)

        var desembolsos = await (
            from pasoCritico in _pnipaConcursosContexto.PasosCritico
            join aporteEntidadPasoCritico in _pnipaConcursosContexto.AportesEntidadPasoCritico
                on pasoCritico.Id equals aporteEntidadPasoCritico.PasoCriticoId
            join proyecto in _pnipaConcursosContexto.Proyectos
                on pasoCritico.ProyectoId equals proyecto.Id
            join postulante in _pnipaConcursosContexto.Postulantes
                on proyecto.PostulanteId equals postulante.Id
            join poa in _pnipaConcursosContexto.Poas
                on aporteEntidadPasoCritico.PoaId equals poa.Id
            join entidad in _pnipaConcursosContexto.Entidades
                on aporteEntidadPasoCritico.EntidadId equals entidad.Id
            join postulanteEntidad in _pnipaConcursosContexto.Postulantes
                on entidad.PostulanteId equals postulanteEntidad.Id
            join pasoCriticoResumen in from pasoCritico in _pnipaConcursosContexto.PasosCritico
                join proyecto in _pnipaConcursosContexto.Proyectos
                    on pasoCritico.ProyectoId equals proyecto.Id
                join cronogramaPoaFinanciera in _pnipaConcursosContexto.CronogramasPoaFinanciera
                    on proyecto.Id equals cronogramaPoaFinanciera.ProyectoId
                join poa in _pnipaConcursosContexto.Poas
                    on cronogramaPoaFinanciera.PoaId equals poa.Id
                where
                    pasoCritico.ProyectoId == proyecto.Id
                    && pasoCritico.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                    && proyecto.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                    && cronogramaPoaFinanciera.EstadoRegistro
                    == EntidadAuditable.EstadoRegistroActivo
                    && poa.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                    && cronogramaPoaFinanciera.Mes >= pasoCritico.MesInicio
                    && cronogramaPoaFinanciera.Mes <= pasoCritico.MesFin
                group new { pasoCritico, cronogramaPoaFinanciera } by new { pasoCritico.Id }
                into agrupador
                select new MontoPasoCriticoModelo
                {
                    PasoCriticoId = agrupador.Key.Id,
                    Monto =
                        agrupador.Sum(grupo => grupo.cronogramaPoaFinanciera.Monto)
                        ?? decimal.Zero
                }
                on pasoCritico.Id equals pasoCriticoResumen.PasoCriticoId
            where
                pasoCritico.ProyectoId == proyecto.Id
                && pasoCritico.Numero == 1
                && pasoCritico.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                && aporteEntidadPasoCritico.EstadoRegistro
                == EntidadAuditable.EstadoRegistroActivo
                && proyecto.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                && postulante.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                && poa.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                && entidad.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                && postulanteEntidad.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
            group new { pasoCritico, aporteEntidadPasoCritico } by new
            {
                pasoCritico.Numero,
                pasoCriticoResumen.Monto,
                postulante.Id
            }
            into agrupador
            select new DesembolsoModelo
            {
                PostulanteId = agrupador.Key.Id,
                Hito = ObtenerNombreHito(agrupador.Key.Numero ?? 0),
                DesembolsoPnipa = ObtenerDesembolsoPnipa(
                    agrupador.Key.Monto,
                    agrupador.Sum(grupo => grupo.aporteEntidadPasoCritico.AporteMonetario)
                )
            }
        ).ToListAsync();

        #endregion

        #region Consulta de valores tabla

        var valoresTabla = await (
            from valorTabla in _pnipaConcursosContexto.ValoresTabla
            where valorTabla.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
            select valorTabla
        ).ToListAsync();

        #endregion

        return (
            from subProyecto in subProyectos
            join vigencia in vigencias
                on new { subProyecto.PostulanteId, CodigoEnvioProyecto = subProyecto.CodigoSubProyecto } equals new
                {
                    vigencia.PostulanteId,
                    vigencia.CodigoEnvioProyecto
                }
            join aporte in aportes on subProyecto.PostulanteId equals aporte.PostulanteId
            join desembolso in desembolsos
                on subProyecto.PostulanteId equals desembolso.PostulanteId
            where vigencia.VigenteOk
            select new ReporteParaGeoVisorModelo
            {
                Id = subProyecto.PostulanteId.ToString(),
                CodigoSubProyecto = subProyecto.CodigoSubProyecto,
                Convocatoria = subProyecto.Convocatoria,
                Ventanilla = subProyecto.Ventanilla,
                InstitucionSuvencionadora = subProyecto.InstitucionSuvencionadora,
                Ubigeo = subProyecto.Ubigeo,
                Longitud = subProyecto.Longitud,
                Latitud = subProyecto.Latitud,
                SubSector = subProyecto.SubSector,
                TipoFondo = subProyecto.TipoFondo,
                TituloSubproyecto = subProyecto.Titulo,
                Departamento = subProyecto.Departamento,
                Provincia = subProyecto.Provincia,
                Distrito = subProyecto.Distrito,
                Omr = subProyecto.Omr ?? "OMR7_LIMA",
                Bonificacion = subProyecto.Bonificacion,
                Tema = subProyecto.Tema,
                EslabonCadena = "[PENDIENTE]",
                Especies =
                    valoresTabla
                        .FirstOrDefault(x => x.TablaId == 52 && x.Id == subProyecto.EspecieId)
                        ?.Descripcion ?? subProyecto.Especie,
                Usuario = subProyecto.Usuario,
                EntidadProponente = subProyecto.EntidadProponente,
                EstadoEjecucion =
                    subProyecto.FechaInicioReal != null ? "Ejecución" : "Con Contrato",
                LinkImagenInicial = subProyecto.LinkImagenInicial,
                LinkImagenes = subProyecto.LinkImagenes,
                NumeroContrato = subProyecto.CodigoContrato,
                AporteEntidadColaboradora = aporte.AporteEntidadColaboradora ?? decimal.Zero,
                AporteEntidadAsociada = aporte.AporteEntidadAsociada ?? decimal.Zero,
                AporteEntidadProponente = aporte.AporteEntidadProponente ?? decimal.Zero,
                AportePnipa = aporte.AportePnipa ?? decimal.Zero,
                TotalSubProyecto = aporte.TotalSubProyecto ?? decimal.Zero,
                Hito = desembolso.Hito,
                DesenbolsoPnipa = desembolso.DesembolsoPnipa ?? decimal.Zero,
                TipoEntidadParticipa = valoresTabla
                    .FirstOrDefault(
                        valorTabla =>
                            valorTabla.TablaId == 59
                            && valorTabla.Id == subProyecto.TipoEntidadParticipaId
                    )
                    ?.Descripcion,
                BeneficioAmbiental = valoresTabla
                    .FirstOrDefault(
                        valorTabla =>
                            valorTabla.TablaId == 60
                            && valorTabla.Id == subProyecto.BeneficioAmbientalId
                    )
                    ?.Descripcion,
                TemaAmbiental = valoresTabla
                    .FirstOrDefault(
                        valorTabla =>
                            valorTabla.TablaId == 61
                            && valorTabla.Id == subProyecto.TemaAmbientalId
                    )
                    ?.Descripcion,
                BeneficioSocial = valoresTabla
                    .FirstOrDefault(
                        valorTabla =>
                            valorTabla.TablaId == 72
                            && valorTabla.Id == subProyecto.BeneficioSocialId
                    )
                    ?.Descripcion,
                NumeroBeneficiariosMujeres = subProyecto.NumeroBeneficiariosMujeres ?? 0,
                NumeroBeneficiariosHombres = subProyecto.NumeroBeneficiariosHombres ?? 0,
                TotalBeneficiarios = subProyecto.TotalBeneficiarios ?? 0,
                SubProyectoEmblematico = subProyecto.IdEmblematico,
                LinkFicha = subProyecto.LinkFicha,
                HambreCero = subProyecto.HambreCero
            }
        ).ToList();
    }

    #region Métodos estáticos

    private static string OntenerVentanilla(int codigoVentanilla)
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

    private static string ObtenerConvocatoria(string? descripcion)
    {
        return (descripcion ?? string.Empty) switch
        {
            "Convocatoría 2017 - 2018" => "PNIPA 2017-2018",
            "Convocatoría 2018 - 2019" => "PNIPA 2018-2019",
            _ => "PNIPA 2017-2018"
        };
    }

    private static string ObtenerNombreOficinaMacroRegional(string? nombreMacroRegion)
    {
        return (nombreMacroRegion ?? string.Empty) switch
        {
            "CA I" => "OMR1_PIURA",
            "CA II" => "OMR2_TARAPOTO",
            "CA III" => "OMR3_ANCASH",
            "CA IV" => "OMR4_JUNIN",
            "CA V" => "OMR5_CUSCO",
            "CA VI" => "OMR6_AREQUIPA",
            "CA VII" => "OMR7_LIMA",
            "CA Sede Central" => "OMR7_LIMA",
            _ => string.Empty
        };
    }

    private static string ObtenerNombreHito(short numero)
    {
        return "H" + numero;
    }

    private static decimal? ObtenerDesembolsoPnipa(decimal monto, decimal? aporteMonetario)
    {
        return monto - aporteMonetario;
    }

    #endregion
}