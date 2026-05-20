namespace ASEDUPH_V2_Web.Models
{
    public class VisitaFamiliar
    {
        public int VisitaFamiliarId { get; set; }
        public int SolicitudBecaId { get; set; }
        public string? TipoVisita { get; set; }
        public string? LugarEntrevista { get; set; }
        public DateTime? FechaVisita { get; set; }
        public TimeSpan? HoraVisita { get; set; }
        public string? PersonaEntrevistada { get; set; }
        public string? ParentescoEntrevistado { get; set; }
        public string? ActitudFamilia { get; set; }
        public string? ApreciacionGeneral { get; set; }
        public string? RecomendacionJunta { get; set; }
        public string? RealizadaPor { get; set; }
        public string? Firma { get; set; }
        public string? ObservacionesFinales { get; set; }

        // Navegación
        public SolicitudBeca? SolicitudBeca { get; set; }
    }
}
