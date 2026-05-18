namespace ASEDUPH_V2_Web.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Municipio { get; set; }
        public string? Departamento { get; set; }
        public string Estado { get; set; } = "Activo";
        public DateTime FechaRegistro { get; set; }
    }
}