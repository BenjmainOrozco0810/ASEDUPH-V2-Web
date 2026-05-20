using System.Net.Http.Json;
using ASEDUPH_V2_Web.Models;

namespace ASEDUPH_V2_Web.Services
{
    public class SeguimientoAcademicoService
    {
        private readonly HttpClient _http;

        public SeguimientoAcademicoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SeguimientoAcademico>> GetSeguimientos()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<SeguimientoAcademico>>(
                    "api/SeguimientoAcademico");
                return resultado ?? new List<SeguimientoAcademico>();
            }
            catch { return new List<SeguimientoAcademico>(); }
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

        public async Task<List<Beca>> GetBecas()
        {
            try
            {
                var resultado = await _http.GetFromJsonAsync<List<Beca>>("api/Becas");
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

        public async Task<(bool exito, string mensaje)> CrearSeguimiento(SeguimientoAcademico seg)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/SeguimientoAcademico", seg);
                if (response.IsSuccessStatusCode)
                    return (true, "Seguimiento registrado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> ActualizarSeguimiento(
            int id, SeguimientoAcademico seg)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/SeguimientoAcademico/{id}", seg);
                if (response.IsSuccessStatusCode)
                    return (true, "Seguimiento actualizado correctamente.");
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }
            catch { return (false, "Error de conexión."); }
        }

        public async Task<(bool exito, string mensaje)> EliminarSeguimiento(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/SeguimientoAcademico/{id}");
                if (response.IsSuccessStatusCode)
                    return (true, "Seguimiento eliminado correctamente.");
                return (false, "Error al eliminar.");
            }
            catch { return (false, "Error de conexión."); }
        }
    }
}
