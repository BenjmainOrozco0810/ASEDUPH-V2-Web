namespace ASEDUPH_V2_Web.Models
{
    public class EvaluacionBeca
    {
        public int EvaluacionBecaId { get; set; }
        public int SolicitudBecaId { get; set; }
        public string? RecomendacionesResponsable { get; set; }
        public string? ClasificacionOtorgada { get; set; }
        public string? DecisionFinal { get; set; }
        public DateTime? FechaDecision { get; set; }
        public string? ObservacionesGenerales { get; set; }
        public string? EvaluadoPor { get; set; }

        // Navegación
        public SolicitudBeca? SolicitudBeca { get; set; }
    }
}
