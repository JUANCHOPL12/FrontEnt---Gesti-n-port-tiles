using FrontEnt_GestionPortatiles_Blazor.DTOs.Accesos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Autenticacion;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Equipos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Estudiantes;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Usuarios;

namespace FrontEnt_GestionPortatiles_Blazor.Servicios
{
    public interface IApiService
    {
        // 1. MÓDULO DE AUTENTICACIÓN Y SEGURIDAD (RF-01, RF-02, RF-03, RNF-08)
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);

        // 2. MÓDULO DE CONTROL DE ACCESOS Y PORTERÍA (RF-04, RF-07, RF-08, RNF-01, RNF-02)
        Task<EstudianteDetalleDto?> VerificarEstudianteAsync(string documento);
        Task<bool> RegistrarAccesoAsync(RegistroAccesoCreateDto accesoDto);
        Task<List<RegistroAccesoReadDto>> ObtenerHistorialAccesosAsync();

        // 3. MÓDULO DE GESTIÓN DE ESTUDIANTES Y EQUIPOS (RF-05, RF-06, RF-09, RNF-04)
        Task<List<EstudianteReadDto>> ObtenerEstudiantesAsync();
        Task<EstudianteReadDto?> ObtenerEstudiantePorIdAsync(int id);
        Task<bool> RegistrarEstudianteAsync(EstudianteCreateUpdateDto estudianteDto);
        Task<bool> ActualizarEstudianteAsync(int id, EstudianteCreateUpdateDto estudianteDto);
        Task<bool> CambiarEstadoEstudianteAsync(int id, string nuevoEstado);

        // 4. MÓDULO DE GESTIÓN DE EQUIPOS Y ACCESORIOS (RF-05, RF-06)
        Task<bool> RegistrarEquipoAsync(CrearEquipoDto equipoDto);
        Task<List<EquipoReadDto>> ObtenerEquiposPorEstudianteAsync(int idEstudiante);

        // 5. MÓDULO DE ADMINISTRACIÓN DE CUENTAS DE USUARIO (RF-10, RNF-03, RNF-08)
        Task<List<UsuarioReadDto>> ObtenerUsuariosAsync();
        Task<bool> CrearUsuarioAsync(UsuarioCreateDto usuarioDto);
        Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateDto usuarioDto);
    }
}