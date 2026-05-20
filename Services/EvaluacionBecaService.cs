using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class EvaluacionBecaService
    {
        private readonly HttpClient _http;

        public EvaluacionBecaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EvaluacionBeca>> GetEvaluaciones()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<EvaluacionBeca>>("api/EvaluacionesBeca");
                return resultado ?? new List<EvaluacionBeca>();
            }
            catch { return new List<EvaluacionBeca>(); }
        }

        public async Task<EvaluacionBeca?> GetEvaluacionPorSolicitud(int solicitudId)
        {
            try
            {
                return await _http.GetFromJsonAsync<EvaluacionBeca>(
                    $"api/EvaluacionesBeca/solicitud/{solicitudId}");
            }
            catch { return null; }
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

        public async Task<(bool exito, string mensaje)> CrearEvaluacion(EvaluacionBeca evaluacion)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/EvaluacionesBeca", evaluacion);
                if (response.IsSuccessStatusCode)
                    return (true, "Evaluación registrada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarEvaluacion(int id, EvaluacionBeca evaluacion)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/EvaluacionesBeca/{id}", evaluacion);
                if (response.IsSuccessStatusCode)
                    return (true, "Evaluación actualizada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> CambiarDecision(int id, string decision)
        {
            try
            {
                var response = await _http.PatchAsJsonAsync(
                    $"api/EvaluacionesBeca/{id}/decision", decision);
                if (response.IsSuccessStatusCode)
                    return (true, "Decisión actualizada correctamente.");
                return (false, "Error al actualizar la decisión.");
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> EliminarEvaluacion(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/EvaluacionesBeca/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Evaluación eliminada correctamente.");
                return (false, "Error al eliminar.");
            }
            catch { return (false, "Error de conexión."); }
        }
    }
}
