using System.Net.Http.Json;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Accesos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Autenticacion;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Equipos;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Estudiantes;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Usuarios;
using FrontEnt_GestionPortatiles_Blazor.DTOs.Catalogos;

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

        public async Task<bool> CrearEstudianteAsync(EstudianteCreateUpdateDto estudianteDto)
        {
            return await RegistrarEstudianteAsync(estudianteDto);
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
        // =========================================================================
        // 6. MÓDULO DE CATÁLOGOS (Facultades, Carreras por Facultad, Marcas, Tipos)
        // Swagger: GET /api/Catalogos/facultades
        // Swagger: GET /api/Catalogos/carreras/facultad/{idFacultad}
        // Swagger: GET /api/Catalogos/marcas
        // Swagger: GET /api/Catalogos/tipos-equipo
        // =========================================================================
        public async Task<List<FacultadDto>> ObtenerFacultadesAsync()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<FacultadDto>>("api/Catalogos/facultades");
                return resultado ?? new List<FacultadDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener facultades: {ex.Message}");
                return new List<FacultadDto>();
            }
        }

        public async Task<List<CarreraDto>> ObtenerCarrerasPorFacultadAsync(int idFacultad)
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<CarreraDto>>($"api/Catalogos/carreras/facultad/{idFacultad}");
                return resultado ?? new List<CarreraDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener carreras para la facultad {idFacultad}: {ex.Message}");
                return new List<CarreraDto>();
            }
        }

        public async Task<List<MarcaDto>> ObtenerMarcasAsync()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<MarcaDto>>("api/Catalogos/marcas");
                return resultado ?? new List<MarcaDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener marcas: {ex.Message}");
                return new List<MarcaDto>();
            }
        }

        public async Task<List<TipoEquipoDto>> ObtenerTiposEquipoAsync()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<TipoEquipoDto>>("api/Catalogos/tipos-equipo");
                return resultado ?? new List<TipoEquipoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de equipo: {ex.Message}");
                return new List<TipoEquipoDto>();
            }
        }

        public async Task<List<PorteriaDto>> ObtenerPorteriasAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<PorteriaDto>>("api/Catalogos/porterias");
                return response ?? new List<PorteriaDto>();
            }
            catch
            {
                return new List<PorteriaDto>();
            }
        }

        public async Task<List<RegistroAccesoReadDto>> ObtenerHistorialAccesoAsync(string numeroDocumento, DateTime? fecha = null, string? serial = null)
        {
            // Validar que el número de documento no sea nulo ni esté vacío
            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                return new List<RegistroAccesoReadDto>();
            }

            try
            {
                var queryParams = new List<string>();

                if (fecha.HasValue)
                    queryParams.Add($"fecha={fecha.Value:yyyy-MM-dd}");

                if (!string.IsNullOrWhiteSpace(serial))
                    queryParams.Add($"serial={Uri.EscapeDataString(serial)}");

                string queryString = queryParams.Any() ? "?" + string.Join("&", queryParams) : "";

                // Asegurar que numeroDocumento.Trim() se agregue correctamente
                string url = $"api/RegistroAccesos/historial/{numeroDocumento.Trim()}{queryString}";

                var response = await _http.GetFromJsonAsync<List<RegistroAccesoReadDto>>(url);
                return response ?? new List<RegistroAccesoReadDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener historial: {ex.Message}");
                return new List<RegistroAccesoReadDto>();
            }
        }
    }
}