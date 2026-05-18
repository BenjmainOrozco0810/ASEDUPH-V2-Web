namespace ASEDUPH_V2_Web.Models
{
    public class SolicitudBeca
    {
        public int SolicitudBecaId { get; set; }
        public int EstudianteId { get; set; }
        public int? CentroEducativoId { get; set; }
        public int AnioSolicitud { get; set; }
        public string? NivelEducativo { get; set; }
        public string? GradoSolicitado { get; set; }
        public decimal? PromedioActual { get; set; }
        public string? MotivoSolicitud { get; set; }
        public string EstadoSolicitud { get; set; } = "Pendiente";
        public DateTime FechaSolicitud { get; set; }
        public string? NombrePersonaCompletaFormulario { get; set; }
        public DateTime? FechaFormulario { get; set; }
        public string? Observaciones { get; set; }

        // Navegación
        public Estudiante? Estudiante { get; set; }
        public CentroEducativo? CentroEducativo { get; set; }
    }

    public class CentroEducativo
    {
        public int CentroEducativoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? TipoCentro { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
