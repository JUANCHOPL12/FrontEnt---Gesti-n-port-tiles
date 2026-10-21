namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Reportes
{
    public class ReporteMovimientoDto
    {
        public int IdRegistro { get; set; }
        public string DocumentoEstudiante { get; set; } = string.Empty;
        public string NombreEstudiante { get; set; } = string.Empty;
        public string SerialEquipo { get; set; } = string.Empty;
        public string MarcaEquipo { get; set; } = "N/A";
        public string NombreGuardia { get; set; } = string.Empty;
        public string NombrePorteria { get; set; } = "Portería Principal";
        public string TipoMovimiento { get; set; } = string.Empty; // Entrada / Salida
        public DateTime FechaHora { get; set; }
    }

    public class ResumenReporteDto
    {
        public int TotalIngresos { get; set; }
        public int TotalSalidas { get; set; }
        public int EquiposActualmenteDentro { get; set; }
    }
}