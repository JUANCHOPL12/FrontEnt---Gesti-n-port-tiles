using FrontEnt_GestionPortatiles_Blazor.DTOs.Accesos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Autenticacion;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Equipos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Estudiantes;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Usuarios;

namespace FrontEnt_GestionPortatiles_Blazor.Servicios
{
    public interface IApiService
    {
        // =========================================================================
        // 1. AUTENTICACIÓN (RF-01, RF-02, RF-03)
        // =========================================================================
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);

        // =========================================================================
        // 2. CONTROL DE PORTERÍA Y REGISTRO DE ACCESOS (RF-07, RF-08, RNF-01)
        // =========================================================================
        Task<EstudianteDetalleDto?> VerificarEstudianteAsync(string numeroDocumento);
        Task<bool> RegistrarAccesoAsync(RegistroAccesoCreateDto accesoDto);

        // =========================================================================
        // 3. GESTIÓN Y BÚSQUEDA DE ESTUDIANTES (RF-04, RF-05, RF-09)
        // =========================================================================
        Task<List<EstudianteReadDto>> ObtenerEstudiantesAsync();
        Task<EstudianteDetalleDto?> ConsultarEstudiantePorDocumentoAsync(string documento);
        Task<bool> RegistrarEstudianteAsync(EstudianteCreateUpdateDto estudianteDto);
        Task<bool> ActualizarEstudianteAsync(int id, EstudianteCreateUpdateDto estudianteDto);
        Task<bool> CambiarEstadoEstudianteAsync(int id, string nuevoEstado);

        // =========================================================================
        // 4. GESTIÓN DE EQUIPOS Y PORTÁTILES (RF-05, RF-06)
        // =========================================================================
        Task<List<EquipoReadDto>> ObtenerEquiposPorEstudianteAsync(string numeroDocumento);
        Task<bool> RegistrarEquipoAsync(CrearEquipoDto equipoDto);
        Task<bool> CambiarEstadoEquipoAsync(int id, string nuevoEstado);

        // =========================================================================
        // 5. ADMINISTRACIÓN DE USUARIOS - RBAC (RF-10, RNF-08)
        // =========================================================================
        Task<List<UsuarioReadDto>> ObtenerUsuariosAsync();
        Task<UsuarioReadDto?> ObtenerUsuarioPorIdAsync(int id);
        Task<bool> CrearUsuarioAsync(UsuarioCreateDto usuarioDto);
        Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateDto usuarioDto);
        Task<bool> DesactivarUsuarioAsync(int id);
    }
}