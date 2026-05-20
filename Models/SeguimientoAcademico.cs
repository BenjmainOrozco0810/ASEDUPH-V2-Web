namespace ASEDUPH_V2_Web.Models
{
    public class SeguimientoAcademico
    {
        public int SeguimientoAcademicoId { get; set; }
        public int EstudianteId { get; set; }
        public int? BecaId { get; set; }
        public int? CentroEducativoId { get; set; }
        public int Anio { get; set; }
        public string? Grado { get; set; }
        public string? NivelEducativo { get; set; }
        public decimal? Promedio { get; set; }
        public string? EstadoAcademico { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Navegación
        public Estudiante? Estudiante { get; set; }
        public Beca? Beca { get; set; }
        public CentroEducativo? CentroEducativo { get; set; }
    }
}
