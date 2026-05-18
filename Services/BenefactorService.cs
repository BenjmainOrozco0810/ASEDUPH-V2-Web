using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class BenefactorService
    {
        private readonly HttpClient _http;

        public BenefactorService(HttpClient http)
        {
            _http = http;
        }

        // ── Benefactores ─────────────────────────────────────────────
        public async Task<List<Benefactor>> GetBenefactores()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Benefactor>>("api/Benefactores");
                return resultado ?? new List<Benefactor>();
            }
            catch { return new List<Benefactor>(); }
        }

        public async Task<(bool exito, string mensaje)> CrearBenefactor(Benefactor benefactor)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Benefactores", benefactor);
                if (response.IsSuccessStatusCode)
                    return (true, "Benefactor creado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarBenefactor(int id, Benefactor benefactor)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Benefactores/{id}", benefactor);
                if (response.IsSuccessStatusCode)
                    return (true, "Benefactor actualizado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> DesactivarBenefactor(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/Benefactores/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Benefactor desactivado correctamente.");
                return (false, "Error al desactivar.");
            }
            catch { return (false, "Error de conexión."); }
        }

        // ── Aportes ──────────────────────────────────────────────────
        public async Task<List<Aporte>> GetAportes()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Aporte>>("api/Aportes");
                return resultado ?? new List<Aporte>();
            }
            catch { return new List<Aporte>(); }
        }

        public async Task<List<Aporte>> GetAportesPorBenefactor(int benefactorId)
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Aporte>>(
                    $"api/Aportes/benefactor/{benefactorId}");
                return resultado ?? new List<Aporte>();
            }
            catch { return new List<Aporte>(); }
        }

        public async Task<(bool exito, string mensaje)> CrearAporte(Aporte aporte)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Aportes", aporte);
                if (response.IsSuccessStatusCode)
                    return (true, "Aporte registrado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarAporte(int id, Aporte aporte)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Aportes/{id}", aporte);
                if (response.IsSuccessStatusCode)
                    return (true, "Aporte actualizado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> EliminarAporte(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/Aportes/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Aporte eliminado correctamente.");
                return (false, "Error al eliminar.");
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<List<Beca>> GetBecas()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Beca>>("api/Becas");
                return resultado ?? new List<Beca>();
            }
            catch { return new List<Beca>(); }
        }
    }
}
