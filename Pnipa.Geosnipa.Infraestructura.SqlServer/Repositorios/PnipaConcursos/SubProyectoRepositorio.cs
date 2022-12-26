﻿using Microsoft.EntityFrameworkCore;
using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;
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

        public async Task<IEnumerable<ReporteVisorModelo>> ObtenerReporteParaGeoVisor()
        {
            var valoresTabla = await (
                from valorTabla in _pnipaConcursosContexto.ValoresTabla
                where valorTabla.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                select valorTabla
            ).ToListAsync();

            var postulantes = await (
                from postulante in _pnipaConcursosContexto.Postulantes
                join postulanteMacroRegion in _pnipaConcursosContexto.PostulantesMacroRegion.DefaultIfEmpty()
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
                join proyecto in _pnipaConcursosContexto.Proyectos
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { proyecto.PostulanteId, proyecto.EstadoRegistro }
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
                join usuario in _pnipaConcursosContexto.Usuarios
                    on new
                    {
                        Id = postulante.UsuarioId,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { usuario.Id, usuario.EstadoRegistro }
                join convocatoria in _pnipaConcursosContexto.VistaConvocatorias
                    on new
                    {
                        Id = postulante.ConvocatoriaId,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { convocatoria.Id, convocatoria.EstadoRegistro }
                join ambitoIntervencion in _pnipaConcursosContexto.VistaAmbitosIntervencion
                    on new { PostulanteId = postulante.Id, Numero = (long)decimal.One } equals new
                    {
                        ambitoIntervencion.PostulanteId,
                        ambitoIntervencion.Numero
                    }
                join planNegocio in _pnipaConcursosContexto.PlanesNegocio.DefaultIfEmpty()
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { planNegocio.PostulanteId, planNegocio.EstadoRegistro }
                join productoPlanNegocio in _pnipaConcursosContexto.ProductosPlanNegocio.DefaultIfEmpty()
                    on new
                    {
                        PlanNegocioId = planNegocio.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new
                    {
                        productoPlanNegocio.PlanNegocioId,
                        productoPlanNegocio.EstadoRegistro
                    }
                join ubigeo in _pnipaConcursosContexto.EntidadProponenteUbigeos.DefaultIfEmpty()
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { ubigeo.PostulanteId, ubigeo.EstadoRegistro }
                join macroRegion in _pnipaConcursosContexto.MacroRegiones.DefaultIfEmpty()
                    on new
                    {
                        Id = postulanteMacroRegion.MacroRegionId,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { macroRegion.Id, macroRegion.EstadoRegistro }
                join factor in _pnipaConcursosContexto.FactoresSubProyecto.DefaultIfEmpty()
                    on new
                    {
                        PostulanteId = postulante.Id,
                        EstadoRegistro = EntidadAuditable.EstadoRegistroActivo
                    } equals new { factor.PostulanteId, factor.EstadoRegistro }
                join temaFactor in _pnipaConcursosContexto.TemasFactorCritico.DefaultIfEmpty()
                    on factor.TemaId equals temaFactor.Id
                join ejecutor in _pnipaConcursosContexto.PostulanteEjecutores.DefaultIfEmpty()
                    on postulante.Id equals ejecutor.PostulanteId
                where
                    postulante.EtapaId > 9
                    && postulante.EstadoRegistro == EntidadAuditable.EstadoRegistroActivo
                select new SubProyectosModelo
                {
                    PostulanteId = postulante.Id,
                    ProyectoId = proyecto.Id,
                    CodigoEnvioProyecto = postulante.CodigoEnvioProyecto ?? default!,
                    Ventanilla = postulante.Ventanilla,
                    EntidadProponente = entidad.Nombre ?? default!
                }
            ).ToListAsync();
            return default!;
        }
    }
}