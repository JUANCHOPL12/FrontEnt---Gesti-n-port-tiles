using FrontEnt_GestionPortatiles_Blazor;
using FrontEnt_GestionPortatiles_Blazor.Servicios;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 1. COMPONENTES RAÍZ Y MAQUETACIÓN BASE
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 2. REGISTRO DE ALMACENAMIENTO LOCAL EN EL NAVEGADOR
// Permite almacenar y recuperar de forma persistente el Token JWT, Rol y Nombre de Usuario (RF-01, RNF-08)
builder.Services.AddBlazoredLocalStorage();

// 3. REGISTRO DEL INTERCEPTOR DE SEGURIDAD JWT
// Intercepta todas las peticiones HTTP y adjunta la cabecera Authorization: Bearer <token>
builder.Services.AddTransient<AuthorizationHandler>();

// 4. CONFIGURACIÓN DEL CLIENTE HTTP CON INTERCEPTOR PARA LA WEB API BACKEND (.NET 9)
builder.Services.AddHttpClient("SGE.ServerAPI", client =>
{
    // Dirección URL base de tu Web API Backend .NET 9
    client.BaseAddress = new Uri("https://localhost:7243/"); 
})
.AddHttpMessageHandler<AuthorizationHandler>();

// 5. REGISTRO DEL CLIENTE HTTP POR DEFECTO
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SGE.ServerAPI"));

// 6. REGISTRO DEL SERVICIO CENTRALIZADO DE COMUNICACIÓN CON LA API (IApiService -> ApiService)
builder.Services.AddScoped<IApiService, ApiService>();

await builder.Build().RunAsync();