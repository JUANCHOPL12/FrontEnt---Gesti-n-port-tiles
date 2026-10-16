using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace FrontEnt_GestionPortatiles_Blazor.Servicios
{
    /// <summary>
    /// Interceptor HTTP (DelegatingHandler) para adjuntar el Token JWT en cada petición saliente (RF-01, RNF-08)
    /// </summary>
    public class AuthorizationHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public AuthorizationHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 1. Obtener el token almacenado en la sesión local del navegador (RF-01)
            var token = await _localStorage.GetItemAsync<string>("sge_token");

            // 2. Si el token existe, adjuntarlo en la cabecera Authorization: Bearer <token>
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // 3. Continuar con la ejecución normal de la solicitud HTTP hacia la Web API Backend
            return await base.SendAsync(request, cancellationToken);
        }
    }
}