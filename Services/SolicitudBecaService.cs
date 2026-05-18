using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class SolicitudBecaService
    {
        private readonly HttpClient _http;

        public SolicitudBecaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SolicitudBeca>> GetSolicitudes()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<SolicitudBeca>>("api/SolicitudesBeca");
                return resultado ?? new List<SolicitudBeca>();
            }
            catch
            {
                return new List<SolicitudBeca>();
            }
        }

        public async Task<SolicitudBeca?> GetSolicitud(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<SolicitudBeca>($"api/SolicitudesBeca/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Estudiante>> GetEstudiantes()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Estudiante>>("api/Estudiantes");
                return resultado ?? new List<Estudiante>();
            }
            catch
            {
                return new List<Estudiante>();
            }
        }

        public async Task<List<CentroEducativo>> GetCentrosEducativos()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<CentroEducativo>>("api/CentrosEducativos");
                return resultado ?? new List<CentroEducativo>();
            }
            catch
            {
                return new List<CentroEducativo>();
            }
        }

        public async Task<(bool exito, string mensaje)> CrearSolicitud(SolicitudBeca solicitud)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/SolicitudesBeca", solicitud);
                if (response.IsSuccessStatusCode)
                    return (true, "Solicitud creada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }

        public async Task<(bool exito, string mensaje)> ActualizarSolicitud(int id, SolicitudBeca solicitud)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/SolicitudesBeca/{id}", solicitud);
                if (response.IsSuccessStatusCode)
                    return (true, "Solicitud actualizada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }

        public async Task<(bool exito, string mensaje)> CambiarEstado(int id, string nuevoEstado)
        {
            try
            {
                var response = await _http.PatchAsJsonAsync(
                    $"api/SolicitudesBeca/{id}/estado", nuevoEstado);
                if (response.IsSuccessStatusCode)
                    return (true, "Estado actualizado correctamente.");
                return (false, "Error al cambiar el estado.");
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }

        public async Task<(bool exito, string mensaje)> CancelarSolicitud(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/SolicitudesBeca/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Solicitud cancelada correctamente.");
                return (false, "Error al cancelar la solicitud.");
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }
    }
}
