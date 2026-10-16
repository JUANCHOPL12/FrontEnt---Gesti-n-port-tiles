using System.ComponentModel.DataAnnotations;

namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Accesos
{
    /// <summary>
    /// DTO para enviar la marcación de entrada o salida hacia la Web API .NET 9 (RF-08, RNF-02)
    /// </summary>
    public class RegistroAccesoCreateDto
    {
        [Required(ErrorMessage = "El identificador del estudiante es obligatorio.")]
        public int IdEstudiante { get; set; }

        // Puede ser nulo si el estudiante ingresa sin equipo portatil registrado
        public int? IdEquipo { get; set; }

        [Required(ErrorMessage = "El identificador de la portería es obligatorio.")]
        public int IdPorteria { get; set; }

        [Required(ErrorMessage = "El tipo de movimiento es obligatorio (Entrada/Salida).")]
        [StringLength(20, ErrorMessage = "El tipo de movimiento no puede exceder los 20 caracteres.")]
        public string TipoMovimiento { get; set; } = string.Empty; // "Entrada" o "Salida"
    }

    /// <summary>
    /// DTO para recibir la respuesta formateada de historial o confirmación de acceso (RF-08)
    /// </summary>
    public class RegistroAccesoReadDto
    {
        public int IdRegistro { get; set; }
        public string DocumentoEstudiante { get; set; } = string.Empty;
        public string NombreEstudiante { get; set; } = string.Empty;
        public string? SerialEquipo { get; set; }
        public string NombreGuardia { get; set; } = string.Empty;
        public int IdPorteria { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
    }
}