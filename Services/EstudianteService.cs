using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class EstudianteService
    {
        private readonly HttpClient _http;

        public EstudianteService(HttpClient http)
        {
            _http = http;
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

        public async Task<Estudiante?> GetEstudiante(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<Estudiante>($"api/Estudiantes/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool exito, string mensaje)> CrearEstudiante(Estudiante estudiante)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Estudiantes", estudiante);
                if (response.IsSuccessStatusCode)
                    return (true, "Estudiante creado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }

        public async Task<(bool exito, string mensaje)> ActualizarEstudiante(int id, Estudiante estudiante)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Estudiantes/{id}", estudiante);
                if (response.IsSuccessStatusCode)
                    return (true, "Estudiante actualizado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }

        public async Task<(bool exito, string mensaje)> DesactivarEstudiante(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/Estudiantes/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Estudiante desactivado correctamente.");
                return (false, "Error al desactivar el estudiante.");
            }
            catch
            {
                return (false, "Error de conexión.");
            }
        }
    }
}