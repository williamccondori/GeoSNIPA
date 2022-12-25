using MediatR;
using Pnipa.Geosnipa.Dominio.Repositorios;

namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Queries.ObtenerReporteVisor;

public class ObtenerReporteVisorHandler : IRequestHandler<ObtenerReporteVisorRequest, IEnumerable<ObtenerReporteVisorResponse>>
{
    private readonly ISubProyectoRepositorio _subProyectoRepositorio;

    public ObtenerReporteVisorHandler(ISubProyectoRepositorio subProyectoRepositorio)
    {
        _subProyectoRepositorio = subProyectoRepositorio;
    }

    public async Task<IEnumerable<ObtenerReporteVisorResponse>> Handle(ObtenerReporteVisorRequest request,
        CancellationToken cancellationToken)
    {
        var resultados = await _subProyectoRepositorio.ObtenerReporteParaGeoVisor();

        return resultados.Select(x => new ObtenerReporteVisorResponse
        {
            CodigoSubProyecto = x.CodigoSubProyecto,
            Convocatoria = x.Convocatoria,
            Ventanilla = x.Ventanilla,
            InstitucionSuvencionadora = x.InstitucionSuvencionadora,
            Ubigeo = x.Ubigeo,
            Longitud = x.Longitud,
            Latitud = x.Latitud,
            SubSector = x.SubSector,
            TipoFondo = x.TipoFondo,
            TituloSubproyecto = x.TituloSubproyecto,
            Departamento = x.Departamento,
            Provincia = x.Provincia,
            Distrito = x.Distrito,
            Omr = x.Omr,
            Bonificacion = x.Bonificacion,
            Tema = x.Tema,
            EslabonCadena = x.EslabonCadena,
            Especies = x.Especies,
            Usuario = x.Usuario,
            EntidadProponente = x.EntidadProponente,
            EstadoEjecucion = x.EstadoEjecucion,
            LinkImagenes = x.LinkImagenes,
            LinkImagenInicial = x.LinkImagenInicial,
            CodigoContrato = x.CodigoContrato,
            AporteEntidadAsociada = x.AporteEntidadAsociada,
            AporteEntidadColaboradora = x.AporteEntidadColaboradora,
            AporteEntidadProponente = x.AporteEntidadProponente,
            AportePnipa = x.AportePnipa,
            TotalSubProyecto = x.TotalSubProyecto,
            Hito = x.Hito,
            DesenbolsoPnipa = x.DesenbolsoPnipa,
            TipoEntidadParticipa = x.TipoEntidadParticipa,
            BeneficioAmbiental = x.BeneficioAmbiental,
            TemaAmbiental = x.TemaAmbiental,
            BeneficioSocial = x.BeneficioSocial,
            NroBeneficiariosMujeres = x.NroBeneficiariosMujeres,
            NroBeneficiariosHombres = x.NroBeneficiariosHombres,
            TotalBeneficiarios = x.TotalBeneficiarios,
            SubProyectoEmblematico = x.SubProyectoEmblematico,
            LinkFicha = x.LinkFicha,
            HambreCero = x.HambreCero
        });
    }
}