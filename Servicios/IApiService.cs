using FrontEnt_GestionPortatiles_Blazor.DTOs.Accesos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Autenticacion;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Equipos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Estudiantes;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Usuarios;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Catalogos;
namespace FrontEnt_GestionPortatiles_Blazor.Servicios
{
    public interface IApiService
    {
        // 1. AUTENTICACIÓN
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);

        // 2. CONTROL DE PORTERÍA
        Task<EstudianteDetalleDto?> VerificarEstudianteAsync(string numeroDocumento);
        Task<bool> RegistrarAccesoAsync(RegistroAccesoCreateDto accesoDto);

        // 3. GESTIÓN DE ESTUDIANTES
        Task<List<EstudianteReadDto>> ObtenerEstudiantesAsync();
        Task<EstudianteDetalleDto?> ConsultarEstudiantePorDocumentoAsync(string documento);
        Task<bool> RegistrarEstudianteAsync(EstudianteCreateUpdateDto estudianteDto);
        Task<bool> ActualizarEstudianteAsync(int id, EstudianteCreateUpdateDto estudianteDto);
        Task<bool> CambiarEstadoEstudianteAsync(int id, string nuevoEstado);

        // 4. GESTIÓN DE EQUIPOS
        Task<List<EquipoReadDto>> ObtenerEquiposPorEstudianteAsync(string numeroDocumento);
        Task<bool> RegistrarEquipoAsync(CrearEquipoDto equipoDto);
        Task<bool> CambiarEstadoEquipoAsync(int id, string nuevoEstado);

        // 5. ADMINISTRACIÓN DE USUARIOS
        Task<List<UsuarioReadDto>> ObtenerUsuariosAsync();
        Task<UsuarioReadDto?> ObtenerUsuarioPorIdAsync(int id);
        Task<bool> CrearUsuarioAsync(UsuarioCreateDto usuarioDto);
        Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateDto usuarioDto);
        Task<bool> DesactivarUsuarioAsync(int id);

        // 6. CATÁLOGOS (Facultades, Carreras, Marcas, Tipos)
        Task<List<FacultadDto>> ObtenerFacultadesAsync();
        Task<List<CarreraDto>> ObtenerCarrerasPorFacultadAsync(int idFacultad);
        Task<List<MarcaDto>> ObtenerMarcasAsync();
        Task<List<TipoEquipoDto>> ObtenerTiposEquipoAsync();

        Task<List<PorteriaDto>> ObtenerPorteriasAsync();
        Task<List<RegistroAccesoReadDto>> ObtenerHistorialAccesoAsync(string numeroDocumento, DateTime? fecha = null, string? serial = null);
    }
}