using System.ComponentModel.DataAnnotations;

namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Autenticacion
{
    /// <summary>
    /// DTO para enviar las credenciales desde la interfaz de usuario Blazor hacia la Web API .NET 9 (RF-01)
    /// </summary>
    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para recibir la respuesta de autenticación exitosa con el Token JWT y Claims de Rol (RF-01, RNF-08)
    /// </summary>
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; // "Guardia", "Administrador" o "SuperAdmin"
    }
}