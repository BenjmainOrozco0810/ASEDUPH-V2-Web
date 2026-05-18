namespace ASEDUPH_V2_Web.Models
{
    public class Beca
    {
        public int BecaId { get; set; }
        public int EstudianteId { get; set; }
        public int? SolicitudBecaId { get; set; }
        public int AnioInicio { get; set; }
        public int? AnioFin { get; set; }
        public string? NivelEducativo { get; set; }
        public string? TipoBeca { get; set; }
        public string EstadoBeca { get; set; } = "Activa";
        public decimal? MontoAprobado { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaAprobacion { get; set; }

        // Navegación
        public Estudiante? Estudiante { get; set; }
        public SolicitudBeca? SolicitudBeca { get; set; }
    }
}
