using System.Net.Http.Json;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Accesos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Autenticacion;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Equipos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Estudiantes;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Usuarios;

namespace FrontEnt_GestionPortatiles_Blazor.Servicios
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        // =========================================================================
        // 1. AUTENTICACIÓN Y SEGURIDAD (RF-01, RF-03)
        // =========================================================================
        public async Task<LoginResponseDto?> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Auth/login", loginDto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        // =========================================================================
        // 2. PORTERÍA Y CONTROL DE ACCESOS (RF-04, RF-07, RF-08, RNF-01, RNF-02)
        // =========================================================================
        public async Task<EstudianteDetalleDto?> VerificarEstudianteAsync(string documento)
        {
            try
            {
                // Búsqueda acelerada por documento (< 2.0s) (RNF-01)
                return await _http.GetFromJsonAsync<EstudianteDetalleDto>($"api/Porteria/verificar/{documento}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RegistrarAccesoAsync(RegistroAccesoCreateDto accesoDto)
        {
            try
            {
                // Registra entrada/salida procesando concurrencia (< 3.0s) (RNF-02)
                var response = await _http.PostAsJsonAsync("api/Porteria/registrar-acceso", accesoDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<RegistroAccesoReadDto>> ObtenerHistorialAccesosAsync()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<RegistroAccesoReadDto>>("api/Porteria/historial");
                return resultado ?? new List<RegistroAccesoReadDto>();
            }
            catch
            {
                return new List<RegistroAccesoReadDto>();
            }
        }

        // =========================================================================
        // 3. GESTIÓN DE ESTUDIANTES Y REGISTRO (RF-05, RF-06, RF-09)
        // =========================================================================
        public async Task<List<EstudianteReadDto>> ObtenerEstudiantesAsync()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<EstudianteReadDto>>("api/Estudiantes");
                return resultado ?? new List<EstudianteReadDto>();
            }
            catch
            {
                return new List<EstudianteReadDto>();
            }
        }

        public async Task<EstudianteReadDto?> ObtenerEstudiantePorIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<EstudianteReadDto>($"api/Estudiantes/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RegistrarEstudianteAsync(EstudianteCreateUpdateDto estudianteDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Estudiantes", estudianteDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ActualizarEstudianteAsync(int id, EstudianteCreateUpdateDto estudianteDto)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Estudiantes/{id}", estudianteDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CambiarEstadoEstudianteAsync(int id, string nuevoEstado)
        {
            try
            {
                var response = await _http.PatchAsync($"api/Estudiantes/{id}/estado?nuevoEstado={nuevoEstado}", null);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // =========================================================================
        // 4. GESTIÓN DE EQUIPOS Y ACCESORIOS (RF-05, RF-06)
        // =========================================================================
        public async Task<bool> RegistrarEquipoAsync(CrearEquipoDto equipoDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Equipos", equipoDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<EquipoReadDto>> ObtenerEquiposPorEstudianteAsync(int idEstudiante)
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<EquipoReadDto>>($"api/Equipos/estudiante/{idEstudiante}");
                return resultado ?? new List<EquipoReadDto>();
            }
            catch
            {
                return new List<EquipoReadDto>();
            }
        }

        // =========================================================================
        // 5. ADMINISTRACIÓN DE CUENTAS DE USUARIO (RF-10, RNF-08)
        // =========================================================================
        public async Task<List<UsuarioReadDto>> ObtenerUsuariosAsync()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<UsuarioReadDto>>("api/Usuarios");
                return resultado ?? new List<UsuarioReadDto>();
            }
            catch
            {
                return new List<UsuarioReadDto>();
            }
        }

        public async Task<bool> CrearUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Usuarios", usuarioDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateDto usuarioDto)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Usuarios/{id}", usuarioDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}