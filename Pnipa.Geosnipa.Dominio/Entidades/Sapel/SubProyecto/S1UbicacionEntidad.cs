﻿namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class S1UbicacionEntidad
{
    public int UbicacionId { get; set; }
    public int SubProyectoId { get; set; }
    public string? TipoUbicacion { get; set; }
    public string? DepartamentoId { get; set; }
    public string? ProvinciaId { get; set; }
    public string? DistritoId { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Latitud { get; set; }
    public string? Longitud { get; set; }
    public char AudEstadoRegistro { get; set; }
}