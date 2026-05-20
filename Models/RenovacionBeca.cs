namespace ASEDUPH_V2_Web.Models
{
    public class RenovacionBeca
    {
        public int RenovacionBecaId { get; set; }
        public int BecaId { get; set; }
        public int? CentroEducativoAnteriorId { get; set; }
        public int? CentroEducativoNuevoId { get; set; }
        public int AnioRenovacion { get; set; }
        public string? AnioCursadoAnterior { get; set; }
        public string? AnioACursar { get; set; }
        public decimal? PromedioFinalAnterior { get; set; }
        public string? TipoApoyoRecibido { get; set; }
        public string? MotivoRenovacion { get; set; }
        public string EstadoRenovacion { get; set; } = "Pendiente";
        public DateTime? FechaSolicitud { get; set; }
        public string? Recomendaciones { get; set; }
        public DateTime? FechaDecision { get; set; }

        // Navegación
        public Beca? Beca { get; set; }
        public CentroEducativo? CentroEducativoAnterior { get; set; }
        public CentroEducativo? CentroEducativoNuevo { get; set; }
    }
}
