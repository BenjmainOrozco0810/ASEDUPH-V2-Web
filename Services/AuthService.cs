using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;

        public UsuarioInfo? UsuarioActual { get; private set; }
        public string? Token { get; private set; }
        public bool EstaAutenticado => !string.IsNullOrEmpty(Token);

        public AuthService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        public async Task<bool> Login(LoginRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Auth/login", request);

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (result == null)
                    return false;

                Token = result.Token;
                UsuarioActual = result.Usuario;

                // Guardar token en localStorage
                await _js.InvokeVoidAsync("localStorage.setItem", "token", Token);
                await _js.InvokeVoidAsync("localStorage.setItem", "usuario",
                    JsonSerializer.Serialize(UsuarioActual));

                // Agregar token a las solicitudes HTTP
                _http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task Logout()
        {
            Token = null;
            UsuarioActual = null;
            _http.DefaultRequestHeaders.Authorization = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", "token");
            await _js.InvokeVoidAsync("localStorage.removeItem", "usuario");
        }

        public async Task InicializarSesion()
        {
            try
            {
                var token = await _js.InvokeAsync<string>("localStorage.getItem", "token");
                var usuarioJson = await _js.InvokeAsync<string>("localStorage.getItem", "usuario");

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(usuarioJson))
                {
                    Token = token;
                    UsuarioActual = JsonSerializer.Deserialize<UsuarioInfo>(usuarioJson);
                    _http.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                }
            }
            catch { }
        }

        public bool TieneRol(string rol)
        {
            return UsuarioActual?.Roles.Contains(rol) ?? false;
        }
    }
}