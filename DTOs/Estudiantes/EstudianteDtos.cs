using System.ComponentModel.DataAnnotations;

namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Estudiantes
{
    /// <summary>
    /// DTO para crear o actualizar la información completa de un alumno y su equipo opcional (RF-05, RF-06)
    /// </summary>
    public class EstudianteCreateUpdateDto
    {
        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellidos { get; set; } = string.Empty;

        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        public int IdCarrera { get; set; }

        public string? FotoPerfilUrl { get; set; }

        // Datos opcionales del equipo portátil (RF-06)
        public string? SerialEquipo { get; set; }
        public int? IdMarca { get; set; }
        public int? IdTipo { get; set; }
        public string? FotoEquipoUrl { get; set; }
        public string? FotoAccesoriosUrl { get; set; }
    }

    /// <summary>
    /// DTO optimizado para la consulta rápida y verificación visual en portería (< 2.0s) (RF-04, RF-07, RNF-01)
    /// </summary>
    public class EstudianteDetalleDto
    {
        public int IdEstudiante { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public int IdCarrera { get; set; }
        public string Estado { get; set; } = string.Empty;

        // Registro fotográfico para control de portería (RF-07, RNF-04)
        public string? FotoPerfilUrl { get; set; }
        public string? FotoEquipoUrl { get; set; }
        public string? FotoAccesoriosUrl { get; set; }

        // Dispositivo asociado
        public string? SerialEquipo { get; set; }
        public bool TieneEquipoRegistrado { get; set; }
    }

    /// <summary>
    /// DTO para la lectura general en listas de administración de alumnos (RF-05, RF-09)
    /// </summary>
    public class EstudianteReadDto
    {
        public int IdEstudiante { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public int IdCarrera { get; set; }
        public string Estado { get; set; } = string.Empty;

        // URLs de imágenes comprimidas (RNF-04)
        public string? FotoPerfilUrl { get; set; }
        public string? FotoEquipoUrl { get; set; }
        public string? FotoAccesoriosUrl { get; set; }

        // Datos del equipo portátil
        public string? SerialEquipo { get; set; }
        public int? IdMarca { get; set; }
        public int? IdTipo { get; set; }
    }

    /// <summary>
    /// DTO simplificado para el registro inicial del estudiante sin equipo (RF-05)
    /// </summary>
    public class EstudianteRegistroDto
    {
        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [StringLength(20)]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        [StringLength(100)]
        public string? CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una carrera.")]
        public int IdCarrera { get; set; }

        public string? FotoPerfilUrl { get; set; }
    }
}