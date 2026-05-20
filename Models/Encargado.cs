namespace ASEDUPH_V2_Web.Models
{
    public class Encargado
    {
        public int EncargadoId { get; set; }
        public int EstudianteId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Parentesco { get; set; }
        public string? EstadoCivil { get; set; }
        public string? DPI { get; set; }
        public string? DpiExtendido { get; set; }
        public string? TelefonoDomiciliar { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Direccion { get; set; }
        public string? Ocupacion { get; set; }
        public string? LugarTrabajo { get; set; }
        public string? TelefonoTrabajo { get; set; }
        public string Estado { get; set; } = "Activo";

        // Navegación
        public Estudiante? Estudiante { get; set; }
    }
}
