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
        // 1. MÓDULO DE AUTENTICACIÓN (RF-01, RF-03)
        // Swagger: POST /api/Auth/login
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
        // 2. MÓDULO DE CONTROL DE PORTERÍA (RF-07, RF-08, RNF-01)
        // Swagger: GET /api/RegistroAccesos/verificar/{numeroDocumento}
        // Swagger: POST /api/RegistroAccesos
        // =========================================================================
        public async Task<EstudianteDetalleDto?> VerificarEstudianteAsync(string numeroDocumento)
        {
            try
            {
                return await _http.GetFromJsonAsync<EstudianteDetalleDto>($"api/RegistroAccesos/verificar/{numeroDocumento}");
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
                var response = await _http.PostAsJsonAsync("api/RegistroAccesos", accesoDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // =========================================================================
        // 3. MÓDULO DE GESTIÓN Y BÚSQUEDA DE ESTUDIANTES (RF-04, RF-05, RF-09)
        // Swagger: GET /api/Estudiantes
        // Swagger: GET /api/Estudiantes/buscar/{documento}
        // Swagger: POST /api/Estudiantes
        // Swagger: PUT /api/Estudiantes/{id}
        // Swagger: PATCH /api/Estudiantes/{id}/estado
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

        public async Task<EstudianteDetalleDto?> ConsultarEstudiantePorDocumentoAsync(string documento)
        {
            try
            {
                return await _http.GetFromJsonAsync<EstudianteDetalleDto>($"api/Estudiantes/buscar/{documento}");
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
                var response = await _http.PatchAsJsonAsync($"api/Estudiantes/{id}/estado", nuevoEstado);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // =========================================================================
        // 4. MÓDULO DE EQUIPOS (RF-05, RF-06)
        // Swagger: GET /api/Equipos/estudiante/{numeroDocumento}
        // Swagger: POST /api/Equipos
        // Swagger: PATCH /api/Equipos/{id}/estado
        // =========================================================================
        public async Task<List<EquipoReadDto>> ObtenerEquiposPorEstudianteAsync(string numeroDocumento)
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<EquipoReadDto>>($"api/Equipos/estudiante/{numeroDocumento}");
                return resultado ?? new List<EquipoReadDto>();
            }
            catch
            {
                return new List<EquipoReadDto>();
            }
        }

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

        public async Task<bool> CambiarEstadoEquipoAsync(int id, string nuevoEstado)
        {
            try
            {
                var response = await _http.PatchAsJsonAsync($"api/Equipos/{id}/estado", nuevoEstado);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // =========================================================================
        // 5. MÓDULO DE ADMINISTRACIÓN DE USUARIOS - RBAC (RF-10, RNF-08)
        // Swagger: GET /api/Usuarios
        // Swagger: POST /api/Usuarios
        // Swagger: GET /api/Usuarios/{id}
        // Swagger: PUT /api/Usuarios/{id}
        // Swagger: PATCH /api/Usuarios/{id}/desactivar
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

        public async Task<UsuarioReadDto?> ObtenerUsuarioPorIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<UsuarioReadDto>($"api/Usuarios/{id}");
            }
            catch
            {
                return null;
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

        public async Task<bool> DesactivarUsuarioAsync(int id)
        {
            try
            {
                var response = await _http.PatchAsync($"api/Usuarios/{id}/desactivar", null);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}