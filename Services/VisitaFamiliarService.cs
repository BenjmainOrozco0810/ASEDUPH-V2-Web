using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class VisitaFamiliarService
    {
        private readonly HttpClient _http;

        public VisitaFamiliarService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<VisitaFamiliar>> GetVisitas()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<VisitaFamiliar>>("api/VisitasFamiliares");
                return resultado ?? new List<VisitaFamiliar>();
            }
            catch { return new List<VisitaFamiliar>(); }
        }

        public async Task<List<SolicitudBeca>> GetSolicitudes()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<SolicitudBeca>>("api/SolicitudesBeca");
                return resultado ?? new List<SolicitudBeca>();
            }
            catch { return new List<SolicitudBeca>(); }
        }

        public async Task<(bool exito, string mensaje)> CrearVisita(VisitaFamiliar visita)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/VisitasFamiliares", visita);
                if (response.IsSuccessStatusCode)
                    return (true, "Visita familiar registrada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarVisita(int id, VisitaFamiliar visita)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/VisitasFamiliares/{id}", visita);
                if (response.IsSuccessStatusCode)
                    return (true, "Visita familiar actualizada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> EliminarVisita(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/VisitasFamiliares/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Visita familiar eliminada correctamente.");
                return (false, "Error al eliminar.");
            }
            catch { return (false, "Error de conexión."); }
        }
    }
}
