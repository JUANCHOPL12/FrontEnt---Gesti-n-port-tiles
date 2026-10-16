using System.ComponentModel.DataAnnotations;

namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Equipos
{
    /// <summary>
    /// DTO para registrar o actualizar un equipo portátil y sus accesorios asociados desde el Frontend (RF-05, RF-06)
    /// </summary>
    public class CrearEquipoDto
    {
        [Required(ErrorMessage = "El ID del estudiante es obligatorio.")]
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "El ID del tipo de equipo es obligatorio.")]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "El ID de la marca es obligatorio.")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "El número de serial es obligatorio.")]
        [StringLength(50, ErrorMessage = "El serial no puede superar los 50 caracteres.")]
        public string Serial { get; set; } = string.Empty;

        [Required(ErrorMessage = "La URL de la foto del equipo es obligatoria.")]
        public string FotoEquipoUrl { get; set; } = string.Empty;

        // Campos opcionales para asociar accesorios en el mismo registro (RF-06)
        public string? DescripcionAccesorio { get; set; }
        public string? FotoAccesoriosUrl { get; set; }
    }

    /// <summary>
    /// DTO para recibir la información detallada de los equipos y accesorios asignados a un alumno (RF-04, RF-07)
    /// </summary>
    public class EquipoReadDto
    {
        public int IdEquipo { get; set; }
        public int IdEstudiante { get; set; }
        public string Serial { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string FotoEquipoUrl { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public List<AccesorioReadDto> Accesorios { get; set; } = new();
    }

    /// <summary>
    /// DTO secundario para deserializar los accesorios de un equipo (RF-06, RF-07)
    /// </summary>
    public class AccesorioReadDto
    {
        public int IdAccesorio { get; set; }
        public string DescripcionAccesorio { get; set; } = string.Empty;
        public string? FotoAccesoriosUrl { get; set; }
    }
}