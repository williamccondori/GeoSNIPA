using MediatR;
using Pnipa.Geosnipa.Dominio.Entidades.Geosnipa;
using Pnipa.Geosnipa.Dominio.Repositorios.Geosnipa;

namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Commands.GuardarReporteParaGeoVisor;

public class
    // ReSharper disable once UnusedType.Global
    GuardarReporteParaGeoVisorHandler : IRequestHandler<GuardarReporteParaGeoVisorRequest,
        GuardarReporteParaGeoVisorResponse>
{
    private readonly ISubProyectoRepositorio _geosnipaSubProyectoRepositorio;
    private readonly Dominio.Repositorios.PnipaConcursos.ISubProyectoRepositorio _pnipaConcursosSubProyectoRepositorio;
    private readonly Dominio.Repositorios.Sapel.ISubProyectoRepositorio _sapelSubProyectoRepositorio;

    public GuardarReporteParaGeoVisorHandler(
        ISubProyectoRepositorio geosnipaSubProyectoRepositorio,
        Dominio.Repositorios.Sapel.ISubProyectoRepositorio sapelSubProyectoRepositorio,
        Dominio.Repositorios.PnipaConcursos.ISubProyectoRepositorio pnipaConcursosSubProyectoRepositorio
    )
    {
        _geosnipaSubProyectoRepositorio = geosnipaSubProyectoRepositorio;
        _sapelSubProyectoRepositorio = sapelSubProyectoRepositorio;
        _pnipaConcursosSubProyectoRepositorio = pnipaConcursosSubProyectoRepositorio;
    }

    public async Task<GuardarReporteParaGeoVisorResponse> Handle(GuardarReporteParaGeoVisorRequest request,
        CancellationToken cancellationToken)
    {
        var reporteParaGeoVisorDesdePnipaConcursos =
            await _pnipaConcursosSubProyectoRepositorio.ObtenerReporteParaGeoVisor();
        reporteParaGeoVisorDesdePnipaConcursos = reporteParaGeoVisorDesdePnipaConcursos.OrderBy(reporte => reporte.Id);

        var reporteParaGeoVisorDesdeSapel = await _sapelSubProyectoRepositorio.ObtenerReporteParaGeoVisor();
        reporteParaGeoVisorDesdeSapel = reporteParaGeoVisorDesdeSapel.OrderBy(reporte => reporte.Id);

        var subProyectos = (from reportePnipaConsursos in reporteParaGeoVisorDesdePnipaConcursos
                select reportePnipaConsursos)
            .Union(from reporteSapel in reporteParaGeoVisorDesdeSapel select reporteSapel)
            .Select(
                reporte =>
                    new SubProyectoEntidad
                    {
                        Id = default!,
                        CodigoSubProyecto = reporte.CodigoSubProyecto,
                        Convocatoria = reporte.Convocatoria,
                        Ventanilla = reporte.Ventanilla,
                        InstitucionSuvencionadora = reporte.InstitucionSuvencionadora,
                        Ubigeo = reporte.Ubigeo,
                        Longitud = reporte.Longitud,
                        Latitud = reporte.Latitud,
                        SubSector = reporte.SubSector,
                        TipoFondo = reporte.TipoFondo,
                        TituloSubproyecto = reporte.TituloSubproyecto,
                        Departamento = reporte.Departamento,
                        Provincia = reporte.Provincia,
                        Distrito = reporte.Distrito,
                        Omr = reporte.Omr,
                        Bonificacion = reporte.Bonificacion,
                        Tema = reporte.Tema,
                        EslabonCadena = reporte.EslabonCadena,
                        Especies = reporte.Especies,
                        Usuario = reporte.Usuario,
                        EntidadProponente = reporte.EntidadProponente,
                        EstadoEjecucion = reporte.EstadoEjecucion,
                        LinkImagenes = reporte.LinkImagenes,
                        LinkImagenInicial = reporte.LinkImagenInicial,
                        NumeroContrato = reporte.NumeroContrato,
                        AporteEntidadAsociada = reporte.AporteEntidadAsociada,
                        AporteEntidadColaboradora = reporte.AporteEntidadColaboradora,
                        AporteEntidadProponente = reporte.AporteEntidadProponente,
                        AportePnipa = reporte.AportePnipa,
                        TotalSubProyecto = reporte.TotalSubProyecto,
                        Hito = reporte.Hito,
                        DesenbolsoPnipa = reporte.DesenbolsoPnipa,
                        TipoEntidadParticipa = reporte.TipoEntidadParticipa,
                        BeneficioAmbiental = reporte.BeneficioAmbiental,
                        TemaAmbiental = reporte.TemaAmbiental,
                        BeneficioSocial = reporte.BeneficioSocial,
                        NumeroBeneficiariosMujeres = reporte.NumeroBeneficiariosMujeres,
                        NumeroBeneficiariosHombres = reporte.NumeroBeneficiariosHombres,
                        TotalBeneficiarios = reporte.TotalBeneficiarios,
                        SubProyectoEmblematico = reporte.SubProyectoEmblematico,
                        LinkFicha = reporte.LinkFicha,
                        HambreCero = reporte.HambreCero
                    }
            ).ToList();

        await _geosnipaSubProyectoRepositorio.EliminarTodos();
        await _geosnipaSubProyectoRepositorio.CrearVarios(subProyectos);

        return new GuardarReporteParaGeoVisorResponse { TotalSubProyectos = subProyectos.Count };
    }
}