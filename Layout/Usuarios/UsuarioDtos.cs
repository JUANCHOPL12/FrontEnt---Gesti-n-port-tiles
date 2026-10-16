using System.ComponentModel.DataAnnotations;

namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Usuarios
{
    /// <summary>
    /// DTO para la creación de cuentas de Guardias y Administradores por parte del SuperAdmin (RF-10, RNF-03)
    /// </summary>
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 3 y 50 caracteres.")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ID de Rol es obligatorio.")]
        public int IdRol { get; set; }
    }

    /// <summary>
    /// DTO para la lectura y despliegue del listado global de usuarios y sus roles asignados (RF-10, RNF-08)
    /// </summary>
    public class UsuarioReadDto
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para la actualización de datos, cambio de contraseña opcional y activación/desactivación de cuentas (RF-10)
    /// </summary>
    public class UsuarioUpdateDto
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        public string NombreCompleto { get; set; } = string.Empty;

        // La contraseña es opcional: solo se enviará si el SuperAdmin desea reestablecerla
        public string? Password { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Estado { get; set; } = "Activo"; // "Activo" o "Inactivo"

        [Required(ErrorMessage = "El ID de Rol es obligatorio.")]
        public int IdRol { get; set; }
    }
}