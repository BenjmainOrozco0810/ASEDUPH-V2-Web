using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class EncargadoService
    {
        private readonly HttpClient _http;

        public EncargadoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Encargado>> GetEncargados()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Encargado>>("api/Encargados");
                return resultado ?? new List<Encargado>();
            }
            catch { return new List<Encargado>(); }
        }

        public async Task<List<Encargado>> GetEncargadosPorEstudiante(int estudianteId)
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Encargado>>(
                    $"api/Encargados/estudiante/{estudianteId}");
                return resultado ?? new List<Encargado>();
            }
            catch { return new List<Encargado>(); }
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

        public async Task<(bool exito, string mensaje)> CrearEncargado(Encargado encargado)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Encargados", encargado);
                if (response.IsSuccessStatusCode)
                    return (true, "Encargado creado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarEncargado(int id, Encargado encargado)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Encargados/{id}", encargado);
                if (response.IsSuccessStatusCode)
                    return (true, "Encargado actualizado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> DesactivarEncargado(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/Encargados/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Encargado desactivado correctamente.");
                return (false, "Error al desactivar.");
            }
            catch { return (false, "Error de conexión."); }
        }
    }
}
