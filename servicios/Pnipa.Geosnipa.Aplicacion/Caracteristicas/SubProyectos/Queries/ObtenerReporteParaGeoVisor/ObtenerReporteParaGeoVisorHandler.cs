using MediatR;
using Pnipa.Geosnipa.Dominio.Repositorios.Geosnipa;

namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Queries.ObtenerReporteParaGeoVisor;

// ReSharper disable once UnusedType.Global
public class ObtenerReporteParaGeoVisorHandler : IRequestHandler<ObtenerReporteParaGeoVisorRequest,
    IEnumerable<ObtenerReporteParaGeoVisorResponse>>
{
    private readonly ISubProyectoRepositorio _subProyectoRepositorio;

    public ObtenerReporteParaGeoVisorHandler(ISubProyectoRepositorio subProyectoRepositorio)
    {
        _subProyectoRepositorio = subProyectoRepositorio;
    }

    public async Task<IEnumerable<ObtenerReporteParaGeoVisorResponse>> Handle(ObtenerReporteParaGeoVisorRequest request,
        CancellationToken cancellationToken)
    {
        var subProyectos = await _subProyectoRepositorio.ObtenerTodos();

        return subProyectos.Select(subProyecto => new ObtenerReporteParaGeoVisorResponse
            {
                CodigoSubProyecto = subProyecto.CodigoSubProyecto,
                Convocatoria = subProyecto.Convocatoria,
                Ventanilla = subProyecto.Ventanilla,
                InstitucionSuvencionadora = subProyecto.InstitucionSuvencionadora,
                Ubigeo = subProyecto.Ubigeo,
                Longitud = subProyecto.Longitud,
                Latitud = subProyecto.Latitud,
                SubSector = subProyecto.SubSector,
                TipoFondo = subProyecto.TipoFondo,
                TituloSubproyecto = subProyecto.TituloSubproyecto,
                Departamento = subProyecto.Departamento,
                Provincia = subProyecto.Provincia,
                Distrito = subProyecto.Distrito,
                Omr = subProyecto.Omr,
                Bonificacion = subProyecto.Bonificacion,
                Tema = subProyecto.Tema,
                EslabonCadena = subProyecto.EslabonCadena,
                Especies = subProyecto.Especies,
                Usuario = subProyecto.Usuario,
                EntidadProponente = subProyecto.EntidadProponente,
                EstadoEjecucion = subProyecto.EstadoEjecucion,
                LinkImagenes = subProyecto.LinkImagenes,
                LinkImagenInicial = subProyecto.LinkImagenInicial,
                NumeroContrato = subProyecto.NumeroContrato,
                AporteEntidadAsociada = subProyecto.AporteEntidadAsociada,
                AporteEntidadColaboradora = subProyecto.AporteEntidadColaboradora,
                AporteEntidadProponente = subProyecto.AporteEntidadProponente,
                AportePnipa = subProyecto.AportePnipa,
                TotalSubProyecto = subProyecto.TotalSubProyecto,
                Hito = subProyecto.Hito,
                DesenbolsoPnipa = subProyecto.DesenbolsoPnipa,
                TipoEntidadParticipa = subProyecto.TipoEntidadParticipa,
                BeneficioAmbiental = subProyecto.BeneficioAmbiental,
                TemaAmbiental = subProyecto.TemaAmbiental,
                BeneficioSocial = subProyecto.BeneficioSocial,
                NumeroBeneficiariosMujeres = subProyecto.NumeroBeneficiariosMujeres,
                NumeroBeneficiariosHombres = subProyecto.NumeroBeneficiariosHombres,
                TotalBeneficiarios = subProyecto.TotalBeneficiarios,
                SubProyectoEmblematico = subProyecto.SubProyectoEmblematico,
                LinkFicha = subProyecto.LinkFicha,
                HambreCero = subProyecto.HambreCero
            }
        );
    }
}