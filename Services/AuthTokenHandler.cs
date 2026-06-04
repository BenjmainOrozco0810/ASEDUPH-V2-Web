using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace ASEDUPH_V2_Web.Services
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IJSRuntime _js;

        public AuthTokenHandler(IJSRuntime js)
        {
            _js = js;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            try
            {
                // Leer el token desde localStorage en cada petición
                var token = await _js.InvokeAsync<string>("localStorage.getItem", "token");

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch
            {
                // Si falla la lectura del token, continuar sin él
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
