using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class RenovacionBecaService
    {
        private readonly HttpClient _http;

        public RenovacionBecaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RenovacionBeca>> GetRenovaciones()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<RenovacionBeca>>(
                    "api/RenovacionBeca");
                return resultado ?? new List<RenovacionBeca>();
            }
            catch { return new List<RenovacionBeca>(); }
        }

        public async Task<List<Beca>> GetBecas()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Beca>>("api/Becas/todas");
                return resultado ?? new List<Beca>();
            }
            catch { return new List<Beca>(); }
        }

        public async Task<List<CentroEducativo>> GetCentros()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<CentroEducativo>>(
                    "api/CentrosEducativos");
                return resultado ?? new List<CentroEducativo>();
            }
            catch { return new List<CentroEducativo>(); }
        }

        public async Task<(bool exito, string mensaje)> CrearRenovacion(RenovacionBeca renovacion)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/RenovacionBeca", renovacion);
                if (response.IsSuccessStatusCode)
                    return (true, "Renovación registrada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarRenovacion(
            int id, RenovacionBeca renovacion)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/RenovacionBeca/{id}", renovacion);
                if (response.IsSuccessStatusCode)
                    return (true, "Renovación actualizada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> CambiarEstado(int id, string nuevoEstado)
        {
            try
            {
                var response = await _http.PatchAsJsonAsync(
                    $"api/RenovacionBeca/{id}/estado", nuevoEstado);
                if (response.IsSuccessStatusCode)
                    return (true, "Estado actualizado correctamente.");
                return (false, "Error al cambiar el estado.");
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> CancelarRenovacion(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/RenovacionBeca/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Renovación cancelada correctamente.");
                return (false, "Error al cancelar.");
            }
            catch { return (false, "Error de conexión."); }
        }
    }
}
