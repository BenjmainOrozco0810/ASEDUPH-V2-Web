using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class BecaService
    {
        private readonly HttpClient _http;

        public BecaService(HttpClient http)
        {
            _http = http;
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

        public async Task<List<Beca>> GetTodasBecas()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Beca>>("api/Becas/todas");
                return resultado ?? new List<Beca>();
            }
            catch { return new List<Beca>(); }
        }

        public async Task<List<SolicitudBeca>> GetSolicitudesAprobadas()
        {
            try
            {
                var todas = await _http.GetFromJsonAsync<List<SolicitudBeca>>("api/SolicitudesBeca");
                return todas?.Where(s => s.EstadoSolicitud == "Aprobada").ToList()
                       ?? new List<SolicitudBeca>();
            }
            catch { return new List<SolicitudBeca>(); }
        }

        public async Task<List<Estudiante>> GetEstudiantes()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Estudiante>>("api/Estudiantes");
                return resultado ?? new List<Estudiante>();
            }
            catch { return new List<Estudiante>(); }
        }

        public async Task<(bool exito, string mensaje)> CrearBeca(Beca beca)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Becas", beca);
                if (response.IsSuccessStatusCode)
                    return (true, "Beca creada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarBeca(int id, Beca beca)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Becas/{id}", beca);
                if (response.IsSuccessStatusCode)
                    return (true, "Beca actualizada correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> CambiarEstado(int id, string nuevoEstado)
        {
            try
            {
                var response = await _http.PatchAsJsonAsync($"api/Becas/{id}/estado", nuevoEstado);
                if (response.IsSuccessStatusCode)
                    return (true, "Estado actualizado correctamente.");
                return (false, "Error al cambiar el estado.");
            }
            catch { return (false, "Error de conexión."); }
        }
    }
}
